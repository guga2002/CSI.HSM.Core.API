using Common.Data.Entities.Enums;

namespace Core.Application.DTOs.Request.Notification;

public class NotificationDto
{
    public required string Title { get; set; }

    public required string Message { get; set; }

    public string? WhatWillRobotSay { get; set; }

    public string? LanguageCode { get; set; }

    public NotificationType NotificationType { get; set; }

    public PriorityEnum PriorityLevel { get; set; }
}
