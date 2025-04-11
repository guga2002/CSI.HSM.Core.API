namespace Core.Application.DTOs.Request.Hotel;

public class LocationRequestDto
{
    public string? Address { get; set; }

    public string? City { get; set; }

    public string? MapUrl { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}
