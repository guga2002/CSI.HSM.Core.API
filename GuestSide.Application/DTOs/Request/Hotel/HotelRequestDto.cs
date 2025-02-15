namespace Core.Application.DTOs.Request.Hotel;

public class HotelRequestDto
{
    public required string Name { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    public int Stars { get; set; }

    public List<string>? Pictures { get; set; }

    public string? Description { get; set; }

    public IEnumerable<string>? Facilities { get; set; }

    public long LanguageId { get; set; }

}
