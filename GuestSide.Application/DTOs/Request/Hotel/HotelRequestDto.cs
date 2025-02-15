using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Request.Hotel;

public class HotelRequestDto
{
    public required string Name { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(255)] 
    public string? Address { get; set; }


    public int Stars { get; set; }

    public string? Description { get; set; }

    public string? LanguageCode { get; set; }

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
