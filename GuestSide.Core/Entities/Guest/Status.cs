using System.ComponentModel.DataAnnotations;
using Core.Core.Entities.Language;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Guest;

[Table("Statuses", Schema = "CSI")]
public class Status : AbstractEntities.AbstractEntity
{
    [StringLength(100)]
    public string? StatusName { get; set; }

    [ForeignKey(nameof(languagePack))]
    public long LanguageId { get; set; }
    public LanguagePack languagePack { get; set; }

    public virtual IEnumerable<Guests> GuestsStatues { get; set; }
}
