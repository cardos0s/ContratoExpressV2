namespace ContratoExpress.Server.Models;

// ─── Supabase user_contracts table row ───
public class UserContractRecord
{
    public string Id { get; set; } = "";
    public string UserId { get; set; } = "";
    public string ContractType { get; set; } = "";
    public string Status { get; set; } = "pending"; // pending | paid | free
    public string? BillingId { get; set; }
    public string? BillingUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

// ─── AbacatePay DTOs ───
public class CreateBillingRequest
{
    public string ContractType { get; set; } = "";
    public string CustomerEmail { get; set; } = "";
    public string? CustomerName { get; set; }
    public string PlanId { get; set; } = "profissional";
}

public class CreateBillingResponse
{
    public bool RequiresPayment { get; set; }
    public string? PaymentUrl { get; set; }
    public string ContractRecordId { get; set; } = "";
    public string Status { get; set; } = "";
}

public class CheckStatusResponse
{
    public string Status { get; set; } = "";
    public bool CanGenerate { get; set; }
}

// ─── AbacatePay API response shapes ───
public class AbacateBillingData
{
    public string? Id { get; set; }
    public string? Url { get; set; }
    public int Amount { get; set; }
    public string? Status { get; set; }
}

public class AbacateApiResponse<T>
{
    public T? Data { get; set; }
    public string? Error { get; set; }
}

// ─── Webhook payload ───
public class AbacateWebhookPayload
{
    public string? Event { get; set; }
    public AbacateWebhookData? Data { get; set; }
}

public class AbacateWebhookData
{
    public AbacateWebhookBilling? Billing { get; set; }
}

public class AbacateWebhookBilling
{
    public string? Id { get; set; }
    public string? Status { get; set; }
}

// ─── Auth ───
public class AuthResponse
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public UserInfo? User { get; set; }
}

public class UserInfo
{
    public string Id { get; set; } = "";
    public string Email { get; set; } = "";
    public int ContractsUsed { get; set; }
    public int TotalCredits { get; set; }
    public int RemainingCredits { get; set; }
}

public class LoginRequest
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}

public class RegisterRequest
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string? Name { get; set; }
}