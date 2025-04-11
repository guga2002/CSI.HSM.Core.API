namespace Core.Application.DTOs.Response.Notification;

public class GuestNotificationResponseDto : AbstractResponse
{
    public long GuestId { get; set; }

    public long NotificationId { get; set; }

    public bool IsRead { get; set; } = false;

    public DateTime SentTime { get; set; } 

    public DateTime? ReadTime { get; set; }

    public bool IsImportant { get; set; }

    public virtual NotificationResponseDto? Notifications { get; set; }
}
