namespace Core.Application.DTOs.Response.Restaurant;

public class RestaurantItemResponseDto
{
    public long Id { get; set; }
    public required string Title { get; set; }

    public required List<string> PhotoUrl { get; set; }

    public string? Description { get; set; }

    public string? Allergens { get; set; }

    public decimal? Price { get; set; }

    public bool IsAvaliable { get; set; }

    public DateTime CreatedAt { get; set; }

    public long RestaurantItemCategoryId { get; set; }

    public long RestaurantId { get; set; }
}
