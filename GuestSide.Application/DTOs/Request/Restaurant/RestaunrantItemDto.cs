using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Application.DTOs.Request.Restaurant;

public class RestaunrantItemDto
{
    public required string Title { get; set; }

    public required List<string> PhotoUrl { get; set; }

    public string? Description { get; set; }

    public string? Allergens { get; set; }

    public decimal? Price { get; set; }
    public bool IsAvaliable { get; set; }

    public long RestaurantItemCategoryId { get; set; }

    public long RestaurantId { get; set; }
}
