using System.Net.Http.Json;
using ContratoExpress.Client.Models;

namespace ContratoExpress.Client.Services;

public class BillingService
{
    private readonly HttpClient _http;

    public BillingService(HttpClient http)
    {
        _http = http;
    }

    public async Task<CreateBillingResponse?> RequestContractAsync(string contractType, string email, string planId = "profissional")
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/billing/create", new CreateBillingRequest
            {
                ContractType = contractType,
                CustomerEmail = email,
                PlanId = planId
            });

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<CreateBillingResponse>();

            return null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<CheckStatusResponse?> CheckStatusAsync(string recordId)
    {
        try
        {
            return await _http.GetFromJsonAsync<CheckStatusResponse>($"api/billing/status/{recordId}");
        }
        catch
        {
            return null;
        }
    }
}