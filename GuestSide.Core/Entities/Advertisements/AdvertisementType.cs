using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Language;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Advertisements;

[Table("AdvertisementTypes", Schema = "CSI")]
public class AdvertisementType : AbstractEntity
{
    [StringLength(100)]
    public required string Name { get; set; }
    [StringLength(100)]
    public string? Description { get; set; }
    public string LanguageCode { get; set; }
    public IEnumerable<Advertisements>? Advertisements { get; set; }
}
