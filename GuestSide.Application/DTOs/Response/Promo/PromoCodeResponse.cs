namespace Core.Application.DTOs.Response.Promo;

public class PromoCodeResponse
{
    public long Id { get; set; }

    public required string Code { get; set; }

    public required string Description { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public decimal? DiscountAmount { get; set; }

    public bool IsPercentage { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime ValidUntil { get; set; }

    public int? UsageLimit { get; set; }

    public int? UsageLimitPerGuest { get; set; }

    public List<long>? ApplicableItemIds { get; set; }

    public List<long>? ApplicableGuestIds { get; set; }

    public bool IsSingleUse { get; set; }

    public int TimesUsed { get; set; }

    public bool IsActive { get; set; }
}
