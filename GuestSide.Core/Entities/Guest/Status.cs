using System.ComponentModel.DataAnnotations;
using Core.Core.Entities.Language;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Guest;

[Table("Statuses", Schema = "CSI")]
public class Status : AbstractEntities.AbstractEntity
{
    [StringLength(100)]
    public string? StatusName { get; set; }

    [StringLength(100)]
    public string? LanguageCode { get; set; }

    public virtual IEnumerable<Guests> GuestsStatues { get; set; }
}
