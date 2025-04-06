namespace Core.Application.DTOs.Response.Notification;

public class StafNotificationResponseDto : AbstractResponse
{
    public long StaffId { get; set; }

    public long NotificationId { get; set; }

    public bool IsRead { get; set; }

    public DateTime SentTime { get; set; } 

    public DateTime? ReadTime { get; set; }

    public bool IsImportant { get; set; }

    public virtual NotificationResponseDto? Notifications { get; set; }

}
