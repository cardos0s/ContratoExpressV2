using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ContratoExpress.Server.Models;
using ContratoExpress.Server.Services;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// ─── Services ───
builder.Services.AddSingleton<StripeService>();
builder.Services.AddSingleton<SupabaseAuthService>();
builder.Services.AddSingleton(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    return new Supabase.Client(
        config["Supabase:Url"]!,
        config["Supabase:AnonKey"]!
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

// ─── CORS ───
var allowedOrigins = builder.Configuration["App:AllowedOrigins"]?.Split(',', StringSplitOptions.RemoveEmptyEntries)
    ?? new[]
    {
        builder.Configuration["App:ClientUrl"] ?? "https://localhost:5002",
        "http://localhost:5002",
        "https://localhost:5002",
    };

builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
    p.WithOrigins(allowedOrigins)
    .AllowAnyHeader()
    .WithMethods("GET", "POST")
    .AllowCredentials()));

var app = builder.Build();

var supabase = app.Services.GetRequiredService<Supabase.Client>();
await supabase.InitializeAsync();

if (!app.Environment.IsDevelopment())
    app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

// ─── Health ───
app.MapGet("/api/health", () => Results.Ok(new { status = "ok", time = DateTime.UtcNow }));

// ─── Auth: Register ───
app.MapPost("/api/auth/register", async (RegisterRequest req, SupabaseAuthService auth, ContractTrackingService tracker) =>
{
    try
    {
        var result = await auth.SignUp(req.Email, req.Password);
        if (result?.User == null)
            return Results.BadRequest(new { error = "Erro ao criar conta." });

        // Supabase may not return access_token on signup (email confirmation enabled).
        // Auto-sign-in the user after registration to get a valid session.
        if (string.IsNullOrEmpty(result.AccessToken))
        {
            try
            {
                var loginResult = await auth.SignIn(req.Email, req.Password);
                if (loginResult?.AccessToken != null)
                    result = loginResult;
            }
            catch
            {
                return Results.BadRequest(new { error = "Conta criada, mas não foi possível fazer login automático. Tente fazer login manualmente." });
            }
        }

        if (string.IsNullOrEmpty(result.AccessToken))
            return Results.BadRequest(new { error = "Conta criada, mas não foi possível fazer login automático. Tente fazer login manualmente." });

        var (used, total, remaining) = await tracker.GetCreditBalanceAsync(result.User!.Id!);

        return Results.Ok(new AuthResponse
        {
            AccessToken = result.AccessToken,
            RefreshToken = result.RefreshToken,
            User = new UserInfo
            {
                Id = result.User.Id!,
                Email = result.User.Email!,
                ContractsUsed = used,
                TotalCredits = total,
                RemainingCredits = remaining
            }
        });
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "Registration failed for {Email}", req.Email);
        return Results.BadRequest(new { error = "Erro ao criar conta. Verifique os dados e tente novamente." });
    }
});

// ─── Auth: Login ───
app.MapPost("/api/auth/login", async (LoginRequest req, SupabaseAuthService auth, ContractTrackingService tracker) =>
{
    try
    {
        var result = await auth.SignIn(req.Email, req.Password);
        if (result?.User == null)
            return Results.Unauthorized();

        var (used, total, remaining) = await tracker.GetCreditBalanceAsync(result.User.Id!);

        return Results.Ok(new AuthResponse
        {
            AccessToken = result.AccessToken,
            RefreshToken = result.RefreshToken,
            User = new UserInfo
            {
                Id = result.User.Id!,
                Email = result.User.Email!,
                ContractsUsed = used,
                TotalCredits = total,
                RemainingCredits = remaining
            }
        });
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "Login failed for {Email}", req.Email);
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

// ─── Billing: Create (Stripe Checkout) ───
app.MapPost("/api/billing/create", async (
    CreateBillingRequest req,
    ClaimsPrincipal user,
    ContractTrackingService tracker,
    StripeService stripe) =>
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

    var plan = stripe.GetPlan(req.PlanId);
    if (plan == null)
        return Results.BadRequest(new { error = "Plano inválido" });

    var session = await stripe.CreateCheckoutSessionAsync(req.PlanId, userId, email);
    if (session == null)
        return Results.StatusCode(502);

    await tracker.CreatePurchaseAsync(userId, session.Id, session.Url!, plan.Value.Credits);

    return Results.Ok(new CreateBillingResponse
    {
        RequiresPayment = true,
        PaymentUrl = session.Url,
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

// ─── Stripe Webhook ───
app.MapPost("/api/webhook/stripe", async (
    HttpContext context,
    ContractTrackingService tracker,
    IConfiguration config,
    ILogger<Program> logger) =>
{
    var json = await new StreamReader(context.Request.Body).ReadToEndAsync();
    var signature = context.Request.Headers["Stripe-Signature"].FirstOrDefault();

    if (string.IsNullOrEmpty(signature))
    {
        logger.LogWarning("Stripe webhook received without signature");
        return Results.BadRequest();
    }

    Event stripeEvent;
    try
    {
        var webhookSecret = config["Stripe:WebhookSecret"]!;
        stripeEvent = EventUtility.ConstructEvent(json, signature, webhookSecret);
    }
    catch (StripeException ex)
    {
        logger.LogWarning(ex, "Stripe webhook signature validation failed");
        return Results.BadRequest();
    }

    if (stripeEvent.Type == EventTypes.CheckoutSessionCompleted)
    {
        var session = stripeEvent.Data.Object as Stripe.Checkout.Session;
        if (session != null)
        {
            logger.LogInformation("Checkout session completed: {SessionId}", session.Id);
            await tracker.MarkPurchasePaidAsync(session.Id);
        }
    }

    return Results.Ok();
});

// ─── Fallback for Blazor WASM routing ───
app.MapFallbackToFile("index.html");

app.Run();
