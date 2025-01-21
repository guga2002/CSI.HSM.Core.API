using GuestSide.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Restaurant;

[Table("RestaunrantItems", Schema = "CSI")]
public class RestaunrantItem : AbstractEntity
{
    public required string Title { get; set; }

    public required List<string> PhotoUrl { get; set; }

    public string? Description { get; set; }

    public string? Allergens { get; set; }

    public decimal? Price { get; set; }

    public bool IsAvaliable { get; set; }

    public DateTime CreatedAt { get; set; }

    [ForeignKey(nameof(restaurantItemCategory))]
    public long RestaurantItemCategoryId { get; set; }

    [ForeignKey(nameof(Restaurants))]
    public long RestaurantId { get; set; }

    public virtual RestaurantItemCategory? restaurantItemCategory { get; set; }
    public virtual Restaurants? Restaurants { get; set; }
    public virtual IEnumerable<RestaurantItemToCart>? RestaurantItemToCarts { get; set; }
}
