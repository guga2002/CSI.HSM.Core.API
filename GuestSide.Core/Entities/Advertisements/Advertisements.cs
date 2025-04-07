using Core.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.Json;

namespace Core.Core.Entities.Advertisements;

[Table("Advertisements", Schema = "CSI")]
[Index(nameof(AdvertisementTypeId))]
public class Advertisement : AbstractEntity, IExistable<Advertisement>
{
    [StringLength(100)]
    public required string Title { get; set; }

    [StringLength(100)]
    public string? Description { get; set; }

    [ForeignKey(nameof(AdvertisementType))]
    public long AdvertisementTypeId { get; set; }

    public AdvertisementType? AdvertisementType { get; set; }

    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? PictureUrlsSerialized { get; set; }

    [NotMapped]
    public List<string>? Pictures
    {
        get => PictureUrlsSerialized == null ? new List<string>() : JsonSerializer.Deserialize<List<string>>(PictureUrlsSerialized);
        set => PictureUrlsSerialized = value == null ? null : JsonSerializer.Serialize(value);
    }

    public Expression<Func<Advertisement, bool>> GetExistencePredicate()
    {
        return i => i.Description == Description && i.AdvertisementTypeId == AdvertisementTypeId;
    }
}
