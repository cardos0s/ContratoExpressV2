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

    public async Task<AuthResult?> SignUp(string email, string password)
    {
        var body = JsonSerializer.Serialize(new { email, password });
        var content = new StringContent(body, Encoding.UTF8, "application/json");
        var response = await _http.PostAsync($"{_baseUrl}/signup", content);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Supabase signup failed: {error}");
        }

        return await JsonSerializer.DeserializeAsync<AuthResult>(
            await response.Content.ReadAsStreamAsync());
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
