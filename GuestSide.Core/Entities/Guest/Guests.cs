using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Entities.Task;

namespace GuestSide.Core.Entities.Guest
{
    [Table("Guests", Schema = "CSI")]
    public class Guests : AbstractEntity
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }


        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CheckOutDate { get; set; }

        [ForeignKey(nameof(Room))]
        public long RoomId{ get; set; }

        public Rooms Room{ get; set; }

        public IEnumerable<Cart>Tasks { get; set; }

        public IEnumerable<GuestNotification> GuestNotifications { get; set; }
    }
}
