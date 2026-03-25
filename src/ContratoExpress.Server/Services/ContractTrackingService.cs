using ContratoExpress.Server.Models;
using Supabase.Postgrest;
using static Supabase.Postgrest.Constants;

namespace ContratoExpress.Server.Services;

public class ContractTrackingService
{
    private readonly Supabase.Client _supabase;
    private readonly IConfiguration _config;
    private readonly ILogger<ContractTrackingService> _logger;

    public ContractTrackingService(Supabase.Client supabase, IConfiguration config, ILogger<ContractTrackingService> logger)
    {
        _supabase = supabase;
        _config = config;
        _logger = logger;
    }

    public async Task<int> GetContractsUsedAsync(string userId)
    {
        try
        {
            var response = await _supabase.From<UserContractRow>()
                .Filter("user_id", Operator.Equals, userId)
                .Get();

            return response.Models.Count;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error counting contracts for user {UserId}", userId);
            return 0;
        }
    }

    public async Task<int> GetTotalCreditsAsync(string userId)
    {
        var freeCredits = _config.GetValue<int>("App:FreeContracts");

        try
        {
            var purchases = await _supabase.From<CreditPurchaseRow>()
                .Filter("user_id", Operator.Equals, userId)
                .Filter("status", Operator.Equals, "paid")
                .Get();

            var paidCredits = purchases.Models.Sum(p => p.Credits);
            return freeCredits + paidCredits;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error counting credits for user {UserId}", userId);
            return freeCredits;
        }
    }

    public async Task<(int Used, int Total, int Remaining)> GetCreditBalanceAsync(string userId)
    {
        var used = await GetContractsUsedAsync(userId);
        var total = await GetTotalCreditsAsync(userId);
        var remaining = Math.Max(0, total - used);
        return (used, total, remaining);
    }

    public async Task<bool> HasCreditsAsync(string userId)
    {
        var (_, _, remaining) = await GetCreditBalanceAsync(userId);
        return remaining > 0;
    }

    public async Task<string> RecordContractAsync(string userId, string contractType, string status)
    {
        var id = Guid.NewGuid().ToString("N")[..16];

        try
        {
            await _supabase.From<UserContractRow>()
                .Insert(new UserContractRow
                {
                    Id = id,
                    UserId = userId,
                    ContractType = contractType,
                    Status = status,
                    CreatedAt = DateTime.UtcNow
                });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error inserting contract record");
        }

        return id;
    }

    public async Task<string> CreatePurchaseAsync(string userId, string billingId, string billingUrl, int credits)
    {
        var id = Guid.NewGuid().ToString("N")[..16];

        try
        {
            await _supabase.From<CreditPurchaseRow>()
                .Insert(new CreditPurchaseRow
                {
                    Id = id,
                    UserId = userId,
                    BillingId = billingId,
                    BillingUrl = billingUrl,
                    Credits = credits,
                    Status = "pending",
                    CreatedAt = DateTime.UtcNow
                });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating purchase record");
        }

        return id;
    }

    public async Task MarkPurchasePaidAsync(string billingId)
    {
        try
        {
            var records = await _supabase.From<CreditPurchaseRow>()
                .Filter("billing_id", Operator.Equals, billingId)
                .Get();

            var record = records.Models.FirstOrDefault();
            if (record != null)
            {
                record.Status = "paid";
                await record.Update<CreditPurchaseRow>();

                _logger.LogInformation("Purchase {Id} paid — {Credits} credits for user {UserId}",
                    record.Id, record.Credits, record.UserId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error marking purchase paid for billing {BillingId}", billingId);
        }
    }
}

// ─── Supabase Row Models ───

[Supabase.Postgrest.Attributes.Table("user_contracts")]
public class UserContractRow : Supabase.Postgrest.Models.BaseModel
{
    [Supabase.Postgrest.Attributes.PrimaryKey("id", false)]
    [Supabase.Postgrest.Attributes.Column("id")]
    public string Id { get; set; } = "";

    [Supabase.Postgrest.Attributes.Column("user_id")]
    public string UserId { get; set; } = "";

    [Supabase.Postgrest.Attributes.Column("contract_type")]
    public string ContractType { get; set; } = "";

    [Supabase.Postgrest.Attributes.Column("status")]
    public string Status { get; set; } = "used";

    [Supabase.Postgrest.Attributes.Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

[Supabase.Postgrest.Attributes.Table("credit_purchases")]
public class CreditPurchaseRow : Supabase.Postgrest.Models.BaseModel
{
    [Supabase.Postgrest.Attributes.PrimaryKey("id", false)]
    [Supabase.Postgrest.Attributes.Column("id")]
    public string Id { get; set; } = "";

    [Supabase.Postgrest.Attributes.Column("user_id")]
    public string UserId { get; set; } = "";

    [Supabase.Postgrest.Attributes.Column("billing_id")]
    public string BillingId { get; set; } = "";

    [Supabase.Postgrest.Attributes.Column("billing_url")]
    public string? BillingUrl { get; set; }

    [Supabase.Postgrest.Attributes.Column("credits")]
    public int Credits { get; set; } = 3;

    [Supabase.Postgrest.Attributes.Column("status")]
    public string Status { get; set; } = "pending";

    [Supabase.Postgrest.Attributes.Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}