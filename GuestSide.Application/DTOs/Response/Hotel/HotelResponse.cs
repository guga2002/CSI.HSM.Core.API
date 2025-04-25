using System.ComponentModel.DataAnnotations;
using Core.Application.DTOs.Response;

namespace Core.Application.DTOs.Response.Hotel;

public class HotelResponse : AbstractResponse
{
    public required string Name { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(255)] // Extended length for detailed addresses
    public string? Address { get; set; }

    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow; // Ensures consistent timestamping

    public int Stars { get; set; }

    public string? Description { get; set; }

    public string? LanguageCode { get; set; }

    public long LocationId { get; set; }

    public List<string>? Pictures
    {
        get;
        set;
    }

    public List<string>? Facilities
    {
        get;
        set;
    }

    public virtual LocationResponse? Location { get; set; }
}
