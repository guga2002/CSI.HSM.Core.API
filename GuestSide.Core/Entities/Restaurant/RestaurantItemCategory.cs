using GuestSide.Core.Entities.AbstractEntities;

namespace GuestSide.Core.Entities.Restaurant
{
    public class RestaurantItemCategory:AbstractEntity
    {
        public required string CategoryName { get; set; }
        public string? Description { get; set; }
        public IEnumerable<RestaunrantItem> restaunrantItems { get; set; }
    }
}
