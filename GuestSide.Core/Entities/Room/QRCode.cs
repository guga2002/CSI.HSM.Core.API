using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Guest;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Room
{
    [Table("QRCodes")]
    public class QRCode:AbstractEntity
    {
        public required string Code { get; set; }

        public DateTime GeneratedDate {  get; set; }

        [ForeignKey(nameof(Guest))]
        public long GuestId {  get; set; }

        public Guests Guest{ get; set; }
    }
}
