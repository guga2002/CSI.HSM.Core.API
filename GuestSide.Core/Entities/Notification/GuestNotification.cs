using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Guest;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Notification
{
    [Table("GuestNotifications", Schema = "CSI")]
    [Index(nameof(GuestId))] 
    [Index(nameof(NotificationId))] 
    [Index(nameof(IsRead))] 
    [Index(nameof(SentTime))] 
    public class GuestNotification : AbstractEntity
    {
        [ForeignKey(nameof(Guest))]
        public long GuestId { get; set; }

        public virtual Guests Guest { get; set; }

        [ForeignKey(nameof(Notifications))]
        public long NotificationId { get; set; }

        public virtual Notifications Notifications { get; set; }

        public bool IsRead { get; set; } = false;

        public DateTime SentTime { get; set; } = DateTime.UtcNow; 

        public DateTime? ReadTime { get; set; } 

        public bool IsImportant { get; set; } = false; 
    }
}