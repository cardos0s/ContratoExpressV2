namespace ContratoExpress.Client.Models;

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
    public bool HasCredits => RemainingCredits > 0;
}

public class CreateBillingRequest
{
    public string ContractType { get; set; } = "";
    public string CustomerEmail { get; set; } = "";
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