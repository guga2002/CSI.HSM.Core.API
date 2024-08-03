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

        [ForeignKey(nameof(Room))]
        public long RoomId {  get; set; }

        public Rooms Room{ get; set; }
    }
}
