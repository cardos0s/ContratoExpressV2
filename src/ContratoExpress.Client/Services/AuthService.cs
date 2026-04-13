using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using ContratoExpress.Client.Models;

namespace ContratoExpress.Client.Services;

public class AuthService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _storage;
    private readonly AuthStateProvider _authState;

    public UserInfo? CurrentUser { get; private set; }
    public bool IsLoggedIn => CurrentUser != null;

    public event Action? OnAuthStateChanged;

    public AuthService(HttpClient http, ILocalStorageService storage, AuthStateProvider authState)
    {
        _http = http;
        _storage = storage;
        _authState = authState;
    }

    public async Task<(bool Success, string? Error)> RegisterAsync(string email, string password)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/auth/register", new RegisterRequest
            {
                Email = email,
                Password = password
            });

            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    var err = await response.Content.ReadFromJsonAsync<JsonElement>();
                    return (false, err.TryGetProperty("error", out var e) ? e.GetString() : "Erro ao registrar");
                }
                catch
                {
                    return (false, "Erro ao criar conta. Tente novamente.");
                }
            }

            var auth = await response.Content.ReadFromJsonAsync<AuthResponse>();
            if (auth?.AccessToken != null)
            {
                await SetAuthAsync(auth);
                return (true, null);
            }

            return (false, "Resposta inválida do servidor");
        }
        catch
        {
            return (false, "Erro de conexão. Verifique sua internet e tente novamente.");
        }
    }

    public async Task<(bool Success, string? Error)> LoginAsync(string email, string password)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", new LoginRequest
            {
                Email = email,
                Password = password
            });

            if (!response.IsSuccessStatusCode)
                return (false, "E-mail ou senha inválidos");

            var auth = await response.Content.ReadFromJsonAsync<AuthResponse>();
            if (auth?.AccessToken != null)
            {
                await SetAuthAsync(auth);
                return (true, null);
            }

            return (false, "Resposta inválida");
        }
        catch
        {
            return (false, "Erro de conexão. Verifique sua internet e tente novamente.");
        }
    }

    public async Task LogoutAsync()
    {
        await _storage.RemoveItemAsync("access_token");
        await _storage.RemoveItemAsync("refresh_token");
        _http.DefaultRequestHeaders.Authorization = null;
        CurrentUser = null;
        _authState.NotifyAuthChanged();
        OnAuthStateChanged?.Invoke();
    }

    public async Task<bool> TryRestoreSessionAsync()
    {
        var token = await _storage.GetItemAsStringAsync("access_token");
        if (string.IsNullOrEmpty(token)) return false;

        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        try
        {
            var user = await _http.GetFromJsonAsync<UserInfo>("api/auth/me");
            if (user != null)
            {
                CurrentUser = user;
                _authState.NotifyAuthChanged();
                OnAuthStateChanged?.Invoke();
                return true;
            }
        }
        catch { }

        await LogoutAsync();
        return false;
    }

    public async Task RefreshUserInfoAsync()
    {
        try
        {
            var user = await _http.GetFromJsonAsync<UserInfo>("api/auth/me");
            if (user != null)
            {
                CurrentUser = user;
                OnAuthStateChanged?.Invoke();
            }
        }
        catch { }
    }

    private async Task SetAuthAsync(AuthResponse auth)
    {
        await _storage.SetItemAsStringAsync("access_token", auth.AccessToken!);
        if (auth.RefreshToken != null)
            await _storage.SetItemAsStringAsync("refresh_token", auth.RefreshToken);

        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.AccessToken);
        CurrentUser = auth.User;
        _authState.NotifyAuthChanged();
        OnAuthStateChanged?.Invoke();
    }
}

// Custom AuthenticationStateProvider for Blazor
public class AuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _storage;
    private ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

    public AuthStateProvider(ILocalStorageService storage)
    {
        _storage = storage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _storage.GetItemAsStringAsync("access_token");
        if (string.IsNullOrEmpty(token))
            return new AuthenticationState(_anonymous);

        // Parse JWT claims
        var claims = ParseClaimsFromJwt(token);
        var identity = new ClaimsIdentity(claims, "jwt");
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    public void NotifyAuthChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var claims = new List<Claim>();
        try
        {
            var payload = jwt.Split('.')[1];
            var padded = payload.Length % 4 == 0 ? payload : payload + new string('=', 4 - payload.Length % 4);
            var bytes = Convert.FromBase64String(padded.Replace('-', '+').Replace('_', '/'));
            var json = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(bytes);

            if (json == null) return claims;

            if (json.TryGetValue("sub", out var sub))
                claims.Add(new Claim(ClaimTypes.NameIdentifier, sub.GetString()!));
            if (json.TryGetValue("email", out var email))
                claims.Add(new Claim(ClaimTypes.Email, email.GetString()!));
        }
        catch { }
        return claims;
    }
}
