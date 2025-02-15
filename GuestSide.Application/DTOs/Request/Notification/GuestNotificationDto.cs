namespace Core.Application.DTOs.Request.Notification;

public class GuestNotificationDto
{
    public long GuestId { get; set; }

    public long NotificationId { get; set; }

    public bool IsImportant { get; set; }
}
