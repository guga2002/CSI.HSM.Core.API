namespace Core.Application.DTOs.Request.Hotel;

public class HotelLightRequestDto
{
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
