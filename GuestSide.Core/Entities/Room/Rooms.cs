using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Guest;

namespace GuestSide.Core.Entities.Room
{
    [Table("Rooms")]
    public class Rooms:AbstractEntity
    {
        public int RoomNumber { get; set; }

        public int Floor { get; set; }

        public bool IsAvailable { get; set; }=true;

        [ForeignKey(nameof(RoomCategory))]
        public long RoomCategoryId { get; set; }

        public RoomCategory RoomCategory { get; set; }

        public IEnumerable<Guests>Guests { get; set; }

        public QRCode QRCode { get; set; }
    }
}
