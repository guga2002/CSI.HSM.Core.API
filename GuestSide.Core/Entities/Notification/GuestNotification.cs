using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Guest;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Notification;

[Table("GuestNotifications", Schema = "CSI")]
public class GuestNotification : AbstractEntity
{

    [ForeignKey(nameof(Guest))]
    public long GuestId { get; set; }
    public Guests Guest { get; set; }

    [ForeignKey(nameof(Notifications))]
    public long NotificationId { get; set; }
    public Notifications Notifications { get; set; }

    public bool IsRead { get; set; } = false;

    public DateTime SentTime { get; set; }
}
