using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ContratoExpress.Server.Models;

namespace ContratoExpress.Server.Services;

public class AbacatePayService
{
    private readonly HttpClient _http;
    private readonly IConfiguration _config;
    private readonly ILogger<AbacatePayService> _logger;

    public AbacatePayService(HttpClient http, IConfiguration config, ILogger<AbacatePayService> logger)
    {
        _http = http;
        _config = config;
        _logger = logger;

        var baseUrl = config["AbacatePay:BaseUrl"]!.TrimEnd('/') + "/";
        _http.BaseAddress = new Uri(baseUrl);

        _http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", config["AbacatePay:ApiKey"]);
        _http.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public (string Name, int PriceInCents, int Credits)? GetPlan(string planId)
    {
        var name = _config[$"AbacatePay:Plans:{planId}:Name"];
        var price = _config.GetValue<int>($"AbacatePay:Plans:{planId}:PriceInCents");
        var credits = _config.GetValue<int>($"AbacatePay:Plans:{planId}:Credits");

        if (string.IsNullOrEmpty(name) || price == 0 || credits == 0)
            return null;

        return (name, price, credits);
    }

    public async Task<AbacateBillingData?> CreateBillingAsync(
        string planId,
        string customerEmail,
        string? customerName)
    {
        var plan = GetPlan(planId);
        if (plan == null)
        {
            _logger.LogError("Plan '{PlanId}' not found in config", planId);
            return null;
        }

        var returnUrl = _config["AbacatePay:ReturnUrl"];
        var completionUrl = _config["AbacatePay:CompletionUrl"];

        var payload = new
        {
            frequency = "ONE_TIME",
            methods = new[] { "PIX" },
            products = new[]
            {
                new
                {
                    externalId = $"plan-{planId}-{Guid.NewGuid().ToString("N")[..8]}",
                    name = plan.Value.Name,
                    description = $"ContratoExpress — {plan.Value.Credits} contrato(s) profissional(is)",
                    quantity = 1,
                    price = plan.Value.PriceInCents
                }
            },
            returnUrl,
            completionUrl,
            customer = new
            {
                email = customerEmail,
                name = customerName ?? customerEmail,
                cellphone = "11999999999",
                taxId = "00000000000"
            }
        };

        var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await _http.PostAsync("v1/billing/create", content);
            var body = await response.Content.ReadAsStringAsync();

            _logger.LogInformation("AbacatePay [{Plan}] response: {Status}", planId, response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("AbacatePay billing failed: {Body}", body);
                return null;
            }

            var result = JsonSerializer.Deserialize<AbacateApiResponse<AbacateBillingData>>(
                body,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return result?.Data;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calling AbacatePay");
            return null;
        }
    }
}