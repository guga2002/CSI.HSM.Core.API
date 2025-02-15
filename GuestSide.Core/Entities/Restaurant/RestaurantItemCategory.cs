using Core.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Restaurant;

[Table("RestaurantItemCategories", Schema = "CSI")]
public class RestaurantItemCategory : AbstractEntity
{
    [StringLength(100)]
    public required string CategoryName { get; set; }
    [StringLength(100)]
    public string? Description { get; set; }
    public IEnumerable<RestaunrantItem> restaunrantItems { get; set; }
}
