using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Entities.Hotel;

namespace GuestSide.Core.Entities.Room
{
    [Table("Rooms", Schema = "CSI")]
    public class Rooms:AbstractEntity
    {
        public int RoomNumber { get; set; }

        public int Floor { get; set; }

        public bool IsAvailable { get; set; }=true;

        [ForeignKey(nameof(RoomCategory))]
        public long RoomCategoryId { get; set; }

        [ForeignKey(nameof(Hotel))]
        public long  HotelId { get; set; }

        public Hotel.Hotel Hotel { get; set; }
        public RoomCategory RoomCategory { get; set; }

        public IEnumerable<Guests>Guests { get; set; }

        public QRCode QRCode { get; set; }
    }
}
