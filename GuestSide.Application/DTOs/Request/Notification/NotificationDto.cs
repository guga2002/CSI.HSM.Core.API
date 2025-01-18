﻿namespace GuestSide.Application.DTOs.Request.Notification
{
    public class NotificationDto
    {
        public required string Title { get; set; }

        public required string Message { get; set; }


        public DateTime NotificationDate { get; set; }

        public bool IsRead { get; set; } = false;

        public long LanguageId { get; set; }
    }
}
