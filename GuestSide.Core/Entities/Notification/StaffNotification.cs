using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Staff;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Notification;

[Table("StaffNotifications", Schema = "CSI")]
public class StaffNotification : AbstractEntity
{
    [ForeignKey(nameof(Staff))]
    public long StaffId { get; set; }
    public Staffs Staff { get; set; }

    [ForeignKey(nameof(Notifications))]
    public long NotificationId { get; set; }
    public Notifications Notifications { get; set; }
}
