using Core.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Advertisements;

[Table("AdvertisementTypes", Schema = "CSI")]
[Index(nameof(Name))] 
[Index(nameof(LanguageCode))]
public class AdvertisementType : AbstractEntity
{
    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(100)]
    public string? Description { get; set; }

    [StringLength(10)] 
    public string? LanguageCode { get; set; }

    public virtual List<Advertisement>? Advertisements { get; set; } 
}