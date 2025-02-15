namespace Core.Application.DTOs.Request.Notification
{
    public class NotificationDto
    {
        public required string Title { get; set; }

        public required string Message { get; set; }

        public DateTime NotificationDate { get; set; }

        public long LanguageId { get; set; }
    }
}
