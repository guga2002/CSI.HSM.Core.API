using System.ComponentModel.DataAnnotations.Schema;
using Core.Application.DTOs.Response.Guest;
using Core.Core.Entities.Guest;
using Core.Core.Entities.Notification;

namespace Core.Application.DTOs.Response.Notification;

public class GuestNotificationResponseDto
{
    public long Id { get; set; }

    public bool IsActive { get; set; }

    public NotificationResponseDto Notifications { get; set; }

    public long GuestId { get; set; }

    public long NotificationId { get; set; }

    public bool IsRead { get; set; } = false;

    public DateTime SentTime { get; set; } 

    public DateTime? ReadTime { get; set; }

    public bool IsImportant { get; set; }
}
