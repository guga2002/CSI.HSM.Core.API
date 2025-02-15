using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Advertisment;

public class AdvertisementTypeResponseDto
{
    public long Id { get; set; }

    public bool IsActive { get; set; } = true;
    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? LanguageCode { get; set; }
}
