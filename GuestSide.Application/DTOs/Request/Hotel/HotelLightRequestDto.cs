using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Request.Hotel;

public class HotelLightRequestDto
{
    [StringLength(255)]
    public string? Address { get; set; }

    public string? Description { get; set; }

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
}
