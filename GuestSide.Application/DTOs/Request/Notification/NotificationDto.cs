using Core.Core.Entities.Notification;

namespace Core.Application.DTOs.Request.Notification
{
    public class NotificationDto
    {
        public required string Title { get; set; }

        public required string Message { get; set; }

        public string? WhatWillRobotSay { get; set; }

        public string? LanguageCode { get; set; }

        public string? NotificationType { get; set; } 

        public NotificationPriority PriorityLevel { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
