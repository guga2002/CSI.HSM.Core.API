using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Restaurant;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Restaurant;

[Table("RestaurantItemToCarts", Schema = "CSI")]
public class RestaurantItemToCart:AbstractEntity
{
    [ForeignKey(nameof(RestaurantCart))]
    public long RestaurantCartId { get; set; }

    [ForeignKey(nameof(RestaunrantItem))]
    public long RestaunrantItemId { get; set; }

    public int Quantity {  get; set; }

    public DateTime CreatedAt {  get; set; }
    public virtual RestaurantCart? RestaurantCart { get; set; }
    public virtual RestaunrantItem? RestaunrantItem { get; set; }
}
