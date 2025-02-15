using Core.Core.Entities.Notification;
using Core.Core.Entities.Staff;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Notification;

public class StafNotificationResponseDto
{
    public long Id { get; set; }

    public long StaffId { get; set; }

    public long NotificationId { get; set; }


    public bool IsRead { get; set; } = false;

    public DateTime SentTime { get; set; } 

    public DateTime? ReadTime { get; set; }

    public bool IsImportant { get; set; } 

    public string? NotificationType { get; set; } // Categorizes notifications (e.g., "System Alert", "Task Reminder")
}
