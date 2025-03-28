using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Core.Core.Entities.AbstractEntities;

namespace Core.Core.Entities.Promo;

[Table("PromoCode", Schema = "CSI")]
public class PromoCode: AbstractEntity,IExistable<PromoCode>
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

    public List<long>? ApplicableItemIds { get; set; } // Optional: restrict to specific products

    public List<long>? ApplicableGuestIds { get; set; } // Optional: target guests

    public bool IsSingleUse { get; set; } // true if only usable once

    public int TimesUsed { get; set; } = 0;

    public Expression<Func<PromoCode, bool>> GetExistencePredicate()
    {
       return i=>i.Description == Description&&i.Code==Code;
    }
}
