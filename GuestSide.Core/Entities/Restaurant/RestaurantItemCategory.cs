using GuestSide.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Restaurant;

[Table("RestaurantItemCategories", Schema = "CSI")]
public class RestaurantItemCategory:AbstractEntity
{
    public required string CategoryName { get; set; }
    public string? Description { get; set; }
    public IEnumerable<RestaunrantItem> restaunrantItems { get; set; }
}
