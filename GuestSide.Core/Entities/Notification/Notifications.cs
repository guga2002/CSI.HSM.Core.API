using Core.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Notification
{
    [Table("Notifications", Schema = "CSI")]
    [Index(nameof(NotificationDate))] 
    [Index(nameof(IsSent))]
    [Index(nameof(LanguageCode))] 
    public class Notifications : AbstractEntity
    {
        [StringLength(150)]
        public required string Title { get; set; }

        [StringLength(500)]
        public required string Message { get; set; }

        [StringLength(300)]
        public string? WhatWillRobotSay { get; set; } = "You got a new notification!";

        public DateTime NotificationDate { get; set; } = DateTime.UtcNow; // Default timestamp

        public bool IsSent { get; set; } = false; // Indicates if the notification has been sent

        public DateTime? SentDate { get; set; } // Stores when the notification was actually sent

        [StringLength(10)] // Optimized for storing language codes
        public string? LanguageCode { get; set; }

        [StringLength(50)]
        public string? NotificationType { get; set; } // Categorizes notifications (e.g., "Reminder", "Offer", "System Alert")

        public NotificationPriority PriorityLevel { get; set; } = NotificationPriority.Medium; // Default priority

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Automatically set when the notification is created

        public virtual List<StaffNotification> StaffNotifications { get; set; } = new(); // Proper ORM handling

        public virtual List<GuestNotification> GuestNotifications { get; set; } = new(); // Proper ORM handling

        public Notifications() { }

        public Notifications(string pattern = "You got a new notification: {0}, {1}")
        {
            WhatWillRobotSay = pattern;
        }
    }

    public enum NotificationPriority
    {
        High,
        Medium,
        Low
    }
}
