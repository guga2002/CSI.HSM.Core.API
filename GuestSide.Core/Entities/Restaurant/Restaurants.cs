using GuestSide.Core.Entities.AbstractEntities;

namespace GuestSide.Core.Entities.Restaurant
{
    public class Restaurants:AbstractEntity
    {
        public string Name { get; set; }
        public string RestaunrantCategory { get; set; } //romeli qveynis samzareuloa
        public IEnumerable<RestaunrantItem> Items { get; set; }

    }
}
