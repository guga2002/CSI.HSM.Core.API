using Core.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Restaurant;

[Table("RestaunrantItems", Schema = "CSI")]
public class RestaunrantItem : AbstractEntity
{
    [StringLength(100)]
    public required string Title { get; set; }

    public required List<string> PhotoUrl { get; set; }

    [StringLength(100)]
    public string? Description { get; set; }

    [StringLength(100)]
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
