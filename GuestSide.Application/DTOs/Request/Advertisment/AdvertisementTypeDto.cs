namespace GuestSide.Application.DTOs.Request.Advertisment;

public class AdvertisementTypeDto
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public long LanguageId { get; set; }
}
