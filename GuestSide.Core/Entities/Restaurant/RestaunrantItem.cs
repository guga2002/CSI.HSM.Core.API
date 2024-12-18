using GuestSide.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Restaurant
{
    public class RestaunrantItem:AbstractEntity
    {
        public required string Title { get; set; }
        public required List<byte[]> PhotoUrl { get; set; }
        public string? Description {  get; set; }
        public string? Allergens {  get; set; }

        [ForeignKey(nameof(restaurantItemCategory))]
        public long RestaurantItemCategoryId {  get; set; }
        public RestaurantItemCategory restaurantItemCategory { get; set; }

        [ForeignKey(nameof(Restaurants))]
        public long RestaurantId { get; set; }
        public Restaurants Restaurants { get; set; }
        public IEnumerable<RestaurantCart> RestaurantCart { get; set; }


    }
}
