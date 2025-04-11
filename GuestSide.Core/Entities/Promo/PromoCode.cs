using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Promo;

[Table("PromoCode", Schema = "CSI")]
public class PromoCode : AbstractEntity, IExistable<PromoCode>
{
    public required string Code { get; set; } // e.g. "WELCOME10", "SPRING2025"

    public required string Description { get; set; }

    public decimal? DiscountPercentage { get; set; } // 10 for 10%

    public decimal? DiscountAmount { get; set; } // 25 for flat $25 off

    public bool IsPercentage => DiscountPercentage.HasValue;

    public DateTime ValidFrom { get; set; }

    public DateTime ValidUntil { get; set; }

    public int? UsageLimit { get; set; } // Max total uses allowed

    public int? UsageLimitPerGuest { get; set; } // Max per user

    [Column(TypeName = "nvarchar(max)")] // Stores JSON-formatted string in the database
    public string? ApplicableItemIdsSerialized { get; set; }

    [NotMapped]
    public List<long> ApplicableItemIds
    {
        get => ApplicableItemIdsSerialized == null ? new List<long>() : System.Text.Json.JsonSerializer.Deserialize<List<long>>(ApplicableItemIdsSerialized);
        set => ApplicableItemIdsSerialized = value == null ? null : System.Text.Json.JsonSerializer.Serialize(value);
    }

    [Column(TypeName = "nvarchar(max)")] // Stores JSON-formatted string in the database
    public string? ApplicableGuestIdsSerialized { get; set; }

    [NotMapped]
    public List<long> ApplicableGuestIds
    {
        get => ApplicableGuestIdsSerialized == null ? new List<long>() : System.Text.Json.JsonSerializer.Deserialize<List<long>>(ApplicableGuestIdsSerialized);
        set => ApplicableGuestIdsSerialized = value == null ? null : System.Text.Json.JsonSerializer.Serialize(value);
    }

    public bool IsSingleUse { get; set; } // true if only usable once

    public int TimesUsed { get; set; } = 0;

    public Expression<Func<PromoCode, bool>> GetExistencePredicate()
    {
        return i => i.Description == Description && i.Code == Code;
    }
}
