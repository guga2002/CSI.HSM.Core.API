namespace Core.Application.DTOs.Request.Advertisment;

public class AdvertismentDto
{
    public required string Title { get; set; }

    public string? Description { get; set; }

    public long AdvertisementTypeId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? LanguageCode { get; set; }

    public List<string>? Pictures { get; set; }
}