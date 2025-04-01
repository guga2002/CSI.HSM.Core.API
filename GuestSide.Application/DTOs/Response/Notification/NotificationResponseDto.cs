using Core.Core.Entities.Notification;

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

    public NotificationType NotificationType { get; set; }

    public NotificationPriority PriorityLevel { get; set; }

    public DateTime CreatedAt { get; set; }
}
