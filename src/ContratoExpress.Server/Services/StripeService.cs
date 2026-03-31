using Stripe;
using Stripe.Checkout;

namespace ContratoExpress.Server.Services;

public class StripeService
{
    private readonly IConfiguration _config;
    private readonly ILogger<StripeService> _logger;

    public StripeService(IConfiguration config, ILogger<StripeService> logger)
    {
        _config = config;
        _logger = logger;
        StripeConfiguration.ApiKey = config["Stripe:SecretKey"];
    }

    public (string Name, int PriceInCents, int Credits)? GetPlan(string planId)
    {
        var name = _config[$"Stripe:Plans:{planId}:Name"];
        var price = _config.GetValue<int>($"Stripe:Plans:{planId}:PriceInCents");
        var credits = _config.GetValue<int>($"Stripe:Plans:{planId}:Credits");

        if (string.IsNullOrEmpty(name) || price == 0 || credits == 0)
            return null;

        return (name, price, credits);
    }

    public async Task<Session?> CreateCheckoutSessionAsync(
        string planId,
        string userId,
        string customerEmail)
    {
        var plan = GetPlan(planId);
        if (plan == null)
        {
            _logger.LogError("Plan '{PlanId}' not found in config", planId);
            return null;
        }

        var successUrl = _config["Stripe:SuccessUrl"] ?? "https://localhost:5002/pagamento-confirmado";
        var cancelUrl = _config["Stripe:CancelUrl"] ?? "https://localhost:5002";

        try
        {
            var options = new SessionCreateOptions
            {
                Mode = "payment",
                CustomerEmail = customerEmail,
                LineItems = new List<SessionLineItemOptions>
                {
                    new()
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "brl",
                            UnitAmount = plan.Value.PriceInCents,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = plan.Value.Name,
                                Description = $"ContratoExpress — {plan.Value.Credits} contrato(s) profissional(is)",
                            },
                        },
                        Quantity = 1,
                    },
                },
                Metadata = new Dictionary<string, string>
                {
                    ["userId"] = userId,
                    ["planId"] = planId,
                    ["credits"] = plan.Value.Credits.ToString(),
                },
                SuccessUrl = successUrl + "?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = cancelUrl,
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            _logger.LogInformation("Stripe Checkout Session created: {SessionId} for plan {PlanId}", session.Id, planId);
            return session;
        }
        catch (StripeException ex)
        {
            _logger.LogError(ex, "Error creating Stripe Checkout Session");
            return null;
        }
    }
}
