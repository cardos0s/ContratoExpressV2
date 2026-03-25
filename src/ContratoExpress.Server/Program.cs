using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ContratoExpress.Server.Models;
using ContratoExpress.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<AbacatePayService>();
builder.Services.AddSingleton(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    return new Supabase.Client(
        config["Supabase:Url"]!,
        config["Supabase:ServiceRoleKey"]!
    );
});
builder.Services.AddScoped<ContractTrackingService>();

// ─── JWT Auth with ES256 (Supabase ECC P-256 public key) ───
static byte[] Base64UrlDecode(string input)
{
    var s = input.Replace('-', '+').Replace('_', '/');
    switch (s.Length % 4)
    {
        case 2: s += "=="; break;
        case 3: s += "="; break;
    }
    return Convert.FromBase64String(s);
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var supabaseUrl = builder.Configuration["Supabase:Url"]!;

        var ecdsa = ECDsa.Create(new ECParameters
        {
            Curve = ECCurve.NamedCurves.nistP256,
            Q = new ECPoint
            {
                X = Base64UrlDecode("bwPzaIj0_SitaIv_WwV7Wp-HTNSxPl8K5a9Gz5_5hZ8"),
                Y = Base64UrlDecode("zOuPiKXZlbTvwFwwoEhuoFtPiJ8ng-JV4CeoWPrmZYY"),
            }
        });

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = $"{supabaseUrl}/auth/v1",
            ValidateAudience = true,
            ValidAudience = "authenticated",
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new ECDsaSecurityKey(ecdsa)
            {
                KeyId = "d7ad384e-d60d-4e9c-9a4f-d8da386e4082"
            },
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
    p.WithOrigins(
        builder.Configuration["App:ClientUrl"] ?? "https://localhost:5002",
        "http://localhost:5002",
        "https://localhost:5002",
        "http://localhost:5003",
        "https://localhost:5003"
    )
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()));

var app = builder.Build();

var supabase = app.Services.GetRequiredService<Supabase.Client>();
await supabase.InitializeAsync();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

// ─── Health ───
app.MapGet("/api/health", () => Results.Ok(new { status = "ok", time = DateTime.UtcNow }));

// ─── Auth: Register ───
app.MapPost("/api/auth/register", async (RegisterRequest req, Supabase.Client supabase, ContractTrackingService tracker) =>
{
    try
    {
        var session = await supabase.Auth.SignUp(req.Email, req.Password);
        if (session?.User == null)
            return Results.BadRequest(new { error = "Erro ao criar conta." });

        var (used, total, remaining) = await tracker.GetCreditBalanceAsync(session.User.Id!);

        return Results.Ok(new AuthResponse
        {
            AccessToken = session.AccessToken,
            RefreshToken = session.RefreshToken,
            User = new UserInfo
            {
                Id = session.User.Id!,
                Email = session.User.Email!,
                ContractsUsed = used,
                TotalCredits = total,
                RemainingCredits = remaining
            }
        });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

// ─── Auth: Login ───
app.MapPost("/api/auth/login", async (LoginRequest req, Supabase.Client supabase, ContractTrackingService tracker) =>
{
    try
    {
        var session = await supabase.Auth.SignIn(req.Email, req.Password);
        if (session?.User == null)
            return Results.Unauthorized();

        var (used, total, remaining) = await tracker.GetCreditBalanceAsync(session.User.Id!);

        return Results.Ok(new AuthResponse
        {
            AccessToken = session.AccessToken,
            RefreshToken = session.RefreshToken,
            User = new UserInfo
            {
                Id = session.User.Id!,
                Email = session.User.Email!,
                ContractsUsed = used,
                TotalCredits = total,
                RemainingCredits = remaining
            }
        });
    }
    catch
    {
        return Results.Unauthorized();
    }
});

// ─── Auth: Me ───
app.MapGet("/api/auth/me", async (ClaimsPrincipal user, ContractTrackingService tracker) =>
{
    var userId = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? user.FindFirstValue("sub");
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();

    var email = user.FindFirstValue(ClaimTypes.Email) ?? user.FindFirstValue("email") ?? "";
    var (used, total, remaining) = await tracker.GetCreditBalanceAsync(userId);

    return Results.Ok(new UserInfo
    {
        Id = userId,
        Email = email,
        ContractsUsed = used,
        TotalCredits = total,
        RemainingCredits = remaining
    });
}).RequireAuthorization();

// ─── Billing: Create ───
app.MapPost("/api/billing/create", async (
    CreateBillingRequest req,
    ClaimsPrincipal user,
    ContractTrackingService tracker,
    AbacatePayService abacate) =>
{
    var userId = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? user.FindFirstValue("sub");
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();

    var email = user.FindFirstValue(ClaimTypes.Email) ?? user.FindFirstValue("email") ?? req.CustomerEmail;
    var hasCredits = await tracker.HasCreditsAsync(userId);

    if (hasCredits)
    {
        var recordId = await tracker.RecordContractAsync(userId, req.ContractType, "used");
        return Results.Ok(new CreateBillingResponse
        {
            RequiresPayment = false,
            ContractRecordId = recordId,
            Status = "free"
        });
    }

    var plan = abacate.GetPlan(req.PlanId);
    if (plan == null)
        return Results.BadRequest(new { error = "Plano inválido" });

    var billing = await abacate.CreateBillingAsync(req.PlanId, email, req.CustomerName);
    if (billing == null)
        return Results.StatusCode(502);

    await tracker.CreatePurchaseAsync(userId, billing.Id!, billing.Url!, plan.Value.Credits);

    return Results.Ok(new CreateBillingResponse
    {
        RequiresPayment = true,
        PaymentUrl = billing.Url,
        ContractRecordId = "",
        Status = "pending"
    });
}).RequireAuthorization();

// ─── Billing: Check credits ───
app.MapGet("/api/billing/credits", async (ClaimsPrincipal user, ContractTrackingService tracker) =>
{
    var userId = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? user.FindFirstValue("sub");
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();

    var (used, total, remaining) = await tracker.GetCreditBalanceAsync(userId);

    return Results.Ok(new CheckStatusResponse
    {
        Status = remaining > 0 ? "active" : "empty",
        CanGenerate = remaining > 0
    });
}).RequireAuthorization();

// ─── Webhook ───
app.MapPost("/api/webhook/abacatepay", async (
    HttpContext context,
    ContractTrackingService tracker,
    ILogger<Program> logger) =>
{
    var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
    logger.LogInformation("AbacatePay webhook: {Body}", body);

    try
    {
        var payload = JsonSerializer.Deserialize<AbacateWebhookPayload>(body,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (payload?.Event == "billing.paid" && payload.Data?.Billing?.Id != null)
        {
            await tracker.MarkPurchasePaidAsync(payload.Data.Billing.Id);
            logger.LogInformation("Purchase paid for billing {Id}", payload.Data.Billing.Id);
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Webhook error");
    }

    return Results.Ok();
});

app.Run();