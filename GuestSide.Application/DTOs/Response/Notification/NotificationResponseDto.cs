

using Core.Core.Entities.Notification;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Notification;

public class NotificationResponseDto
{
    public long Id { get; set; }

    public required string Title { get; set; }

    public required string Message { get; set; }

    public string? WhatWillRobotSay { get; set; } 

    public DateTime NotificationDate { get; set; }

    public bool IsSent { get; set; }

    public DateTime? SentDate { get; set; } // Stores when the notification was actually sent

    public string? LanguageCode { get; set; }

    public string? NotificationType { get; set; } // Categorizes notifications (e.g., "Reminder", "Offer", "System Alert")

    public NotificationPriority PriorityLevel { get; set; }

    public DateTime CreatedAt { get; set; }
}
