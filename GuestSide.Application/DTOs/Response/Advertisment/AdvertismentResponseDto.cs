
using Core.Application.DTOs.Response;

public class AdvertismentResponseDto : AbstractResponse
{
    public required string Title { get; set; }

    public string? Description { get; set; }

    public long AdvertisementTypeId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? LanguageCode { get; set; }

    public List<string>? Pictures { get; set; }
}
