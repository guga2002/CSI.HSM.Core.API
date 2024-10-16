using GuestSide.Core.Entities.Notification;

namespace GuestSide.Application.DTOs.Notification
{
    public class StafNotificationDto
    {
        public long StaffId { get; set; }

        public long NotificationId { get; set; }

        public NotificationDto Notification { get; set; }
    }
}
