using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Guest;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Notification
{
    [Table("GuestNotifications")]
    public class GuestNotification:AbstractEntity
    {

        [ForeignKey(nameof(Guest))]
        public long GuestId { get; set; }
        public Guests Guest { get; set; }

        [ForeignKey(nameof(Notifications))]
        public long NotificationId { get; set; }
        public Notifications Notifications { get; set; }
    }
}
