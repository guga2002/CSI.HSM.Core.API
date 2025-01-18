using GuestSide.Core.Entities.Restaurant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Application.DTOs.Request.Restaurant;

public class RestaurantItemToCartDto
{
    public long RestaurantCartId { get; set; }

    public long RestaunrantItemId { get; set; }

    public int Quantity { get; set; }

}
