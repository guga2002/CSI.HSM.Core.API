namespace Core.Application.DTOs.Response.Hotel;

public class LocationResponse
{
    public long Id { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public string? Address { get; set; }

    public string? MapUrl { get; set; }

    public long HotelId { get; set; }
}
