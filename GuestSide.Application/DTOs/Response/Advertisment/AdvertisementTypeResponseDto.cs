namespace Core.Application.DTOs.Response.Advertisment;

public class AdvertisementTypeResponseDto: AbstractResponse
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? LanguageCode { get; set; }
}
