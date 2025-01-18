namespace Core.Application.DTOs.Response.Restaurant;

public class RestaurantItemToCartResponseDto
{
    public long Id { get; set; }

    public long RestaurantCartId { get; set; }

    public long RestaunrantItemId { get; set; }

    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; }
}
