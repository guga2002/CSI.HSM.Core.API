using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Guest;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Guest
{
    [Table("GuestLanguages", Schema = "CSI")]
    public class GuestActiveLanguage : AbstractEntity
    {
        [ForeignKey("Guest")]
        public long GuestID { get; set; }
        public string LanguageCode { get; set; }
        public DateTime SetDate { get; set; }
        public Guests Guest { get; set; }
    }
}
