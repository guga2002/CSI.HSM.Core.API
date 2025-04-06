using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Staff;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Notification;

[Table("StaffNotifications", Schema = "CSI")]
[Index(nameof(StaffId))] 
[Index(nameof(NotificationId))] 
[Index(nameof(IsRead))] 
public class StaffNotification : AbstractEntity
{
    [ForeignKey(nameof(StaffMember))]
    public long StaffId { get; set; }

    public virtual Staffs? StaffMember { get; set; } 

    [ForeignKey(nameof(Notifications))]
    public long NotificationId { get; set; }

    public virtual Notifications? Notifications { get; set; }

    public bool IsRead { get; set; } = false; 

    public DateTime SentTime { get; set; } = DateTime.UtcNow; 

    public DateTime? ReadTime { get; set; } 

    public bool IsImportant { get; set; } = false; // Marks high-priority notifications
}