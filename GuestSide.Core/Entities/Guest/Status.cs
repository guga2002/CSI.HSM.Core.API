using GuestSide.Core.Entities.Language;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Guest
{
    [Table("Statuses",Schema ="CSI")]
    public class Status:AbstractEntities.AbstractEntity
    {
        public string  StatusName { get; set; }

        [ForeignKey(nameof(languagePack))]
        public long LanguageId { get; set; }
        public LanguagePack languagePack { get; set; }

        public virtual IEnumerable<Guests> GuestsStatues { get; set; }
    }
}
