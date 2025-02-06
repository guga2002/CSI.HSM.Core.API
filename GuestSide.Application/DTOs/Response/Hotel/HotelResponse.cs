using GuestSide.Core.Entities.Hotel.GeoLocation;

namespace GuestSide.Application.DTOs.Response.Hotel;

public class HotelResponse
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    public DateTime RegistrationDate { get; set; }

    public int Stars { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public List<string>? Pictures { get; set; }

    public IEnumerable<string>? Facilities { get; set; }

    public long LanguageId { get; set; }

    public virtual LocationResponse? Location { get; set; }
}
