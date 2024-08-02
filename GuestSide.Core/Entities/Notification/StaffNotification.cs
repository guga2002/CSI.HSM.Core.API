using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Staff;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Notification
{
    [Table("StaffNotifications")]
    public class StaffNotification:AbstractEntity
    {
        [ForeignKey(nameof(Staff))]
        public long StaffId { get; set; }
        public Staffs Staff { get; set; }

        [ForeignKey(nameof(Notifications))]
        public long NotificationId { get; set; }
        public Notifications Notifications { get; set; }
    }
}
