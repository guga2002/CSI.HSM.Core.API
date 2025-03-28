namespace Core.Application.DTOs.Request.Promo
{
    public class PromoCodeDto
    {
        public required string Code { get; set; } 

        public required string Description { get; set; }

        public decimal? DiscountPercentage { get; set; } 

        public decimal? DiscountAmount { get; set; } 

        public bool IsPercentage => DiscountPercentage.HasValue;

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }

        public int? UsageLimit { get; set; }

        public int? UsageLimitPerGuest { get; set; } 

        public List<long>? ApplicableItemIds { get; set; }

        public List<long>? ApplicableGuestIds { get; set; } 

        public bool IsSingleUse { get; set; }
    }
}
