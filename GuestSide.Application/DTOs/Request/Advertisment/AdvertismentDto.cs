using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Request.Advertisment;
public class AdvertismentDto
{
    public required string Title { get; set; }

    public string? Description { get; set; }

    public long AdvertisementTypeId { get; set; }

    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    public long LanguageId { get; set; }

    public List<byte[]> Pictures { get; set; }
}