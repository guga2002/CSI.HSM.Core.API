using Domain.Core.Entities.AbstractEntities;
using Domain.Core.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities.Notification;

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

    public NotificationType NotificationType { get; set; }

    public PriorityEnum PriorityLevel { get; set; } = PriorityEnum.Medium; // Default priority

    public virtual List<StaffNotification> StaffNotifications { get; set; } = new(); // Proper ORM handling

    public virtual List<GuestNotification> GuestNotifications { get; set; } = new(); // Proper ORM handling

    public Notifications() { }

    public Notifications(string pattern = "You got a new notification: {0}, {1}")
    {
        WhatWillRobotSay = pattern;
    }
}

