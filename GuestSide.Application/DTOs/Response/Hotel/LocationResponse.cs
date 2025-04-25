using Core.Application.DTOs.Response;

namespace Core.Application.DTOs.Response.Hotel;

public class LocationResponse : AbstractResponse
{
    public string? Address { get; set; }

    public string? City { get; set; }

    public string? MapUrl { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public virtual HotelResponse? Hotel { get; set; } // Virtual for lazy loading
}
