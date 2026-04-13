using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContratoExpress.Server.Services;

public class SupabaseAuthService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;

    public SupabaseAuthService(IConfiguration config)
    {
        var supabaseUrl = config["Supabase:Url"]!;
        var apiKey = config["Supabase:ServiceRoleKey"]!;

        _baseUrl = $"{supabaseUrl}/auth/v1";
        _http = new HttpClient();
        _http.DefaultRequestHeaders.Add("apikey", apiKey);
        _http.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    }

    /// <summary>
    /// Creates a user via the Admin API (no rate limit, auto-confirms email),
    /// then signs them in to get a valid session token.
    /// </summary>
    public async Task<(AuthResult? Result, string? Error)> SignUp(string email, string password)
    {
        // 1. Create user via Admin API — bypasses rate limits and auto-confirms email
        var adminBody = JsonSerializer.Serialize(new
        {
            email,
            password,
            email_confirm = true
        });
        var adminContent = new StringContent(adminBody, Encoding.UTF8, "application/json");
        var adminResponse = await _http.PostAsync($"{_baseUrl}/admin/users", adminContent);

        if (!adminResponse.IsSuccessStatusCode)
        {
            var error = await adminResponse.Content.ReadAsStringAsync();
            return (null, error);
        }

        // 2. Parse the created user (admin endpoint returns user object, not a session)
        var adminResult = await JsonSerializer.DeserializeAsync<AdminUserResult>(
            await adminResponse.Content.ReadAsStreamAsync());

        if (adminResult?.Id == null)
            return (null, "Erro ao criar usuário.");

        // 3. Sign in to get access_token + refresh_token
        try
        {
            var session = await SignIn(email, password);
            return (session, null);
        }
        catch (Exception ex)
        {
            return (null, $"Conta criada, mas login falhou: {ex.Message}");
        }
    }

    public async Task<AuthResult?> SignIn(string email, string password)
    {
        var body = JsonSerializer.Serialize(new { email, password });
        var content = new StringContent(body, Encoding.UTF8, "application/json");
        var response = await _http.PostAsync($"{_baseUrl}/token?grant_type=password", content);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Supabase login failed: {error}");
        }

        return await JsonSerializer.DeserializeAsync<AuthResult>(
            await response.Content.ReadAsStreamAsync());
    }
}

public class AuthResult
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }

    [JsonPropertyName("user")]
    public AuthUser? User { get; set; }
}

public class AuthUser
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }
}

public class AdminUserResult
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }
}
