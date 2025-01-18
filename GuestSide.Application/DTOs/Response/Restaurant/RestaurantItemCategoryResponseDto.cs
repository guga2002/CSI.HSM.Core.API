namespace Core.Application.DTOs.Response.Restaurant;

public class RestaurantItemCategoryResponseDto
{
    public long Id { get; set; }
    public required string CategoryName { get; set; }
    public string? Description { get; set; }
}
