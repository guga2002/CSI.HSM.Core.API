using Core.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Core.Entities.Advertisements;

[Table("AdvertisementTypes", Schema = "CSI")]
[Index(nameof(Name))]
[Index(nameof(LanguageCode))]
public class AdvertisementType : AbstractEntity, IExistable<AdvertisementType>
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? LanguageCode { get; set; }

    public virtual List<Advertisement>? Advertisements { get; set; }

    public Expression<Func<AdvertisementType, bool>> GetExistencePredicate()
    {
        return i => i.Name == Name && i.LanguageCode == LanguageCode;
    }
}