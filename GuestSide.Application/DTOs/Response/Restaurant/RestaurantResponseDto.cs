namespace Core.Application.DTOs.Response.Restaurant;

public class RestaurantResponseDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public string? RestaunrantCategory { get; set; } //romeli qveynis samzareuloa
}
