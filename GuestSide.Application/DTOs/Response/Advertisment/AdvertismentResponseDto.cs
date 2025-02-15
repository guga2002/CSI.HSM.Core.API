using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Advertisment;

public class AdvertismentResponseDto
{
    public long Id { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public long AdvertisementTypeId { get; set; }

    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    public bool IsActive { get; set; }

    public long LanguageId { get; set; }

    public required List<byte[]> Pictures { get; set; }
}
