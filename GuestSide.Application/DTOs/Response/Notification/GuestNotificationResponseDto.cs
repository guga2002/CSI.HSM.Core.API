using Core.Application.DTOs.Response.Guest;

namespace Core.Application.DTOs.Response.Notification;

public class GuestNotificationResponseDto
{
    public long GuestId { get; set; }
    public GuestResponseDto Guest { get; set; }

    public long NotificationId { get; set; }
    public NotificationResponseDto Notifications { get; set; }

    public bool IsRead { get; set; } = false;

    public DateTime SentTime { get; set; }
}
