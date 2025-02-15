using Core.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Advertisements;

[Table("Advertisements", Schema = "CSI")]
[Index(nameof(AdvertisementTypeId))] 
[Index(nameof(StartDate))] 
[Index(nameof(EndDate))] 
[Index(nameof(LanguageCode))] 
public class Advertisement : AbstractEntity
{
    [StringLength(100)]
    public required string Title { get; set; }
    [StringLength(100)]
    public string? Description { get; set; }

    [ForeignKey(nameof(AdvertisementType))]
    public long AdvertisementTypeId { get; set; }

    public AdvertisementType AdvertisementType { get; set; }

    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    [StringLength(100)]
    public string? LanguageCode { get; set; }

    public List<string>? PicturesUrl { get; set; }
}
