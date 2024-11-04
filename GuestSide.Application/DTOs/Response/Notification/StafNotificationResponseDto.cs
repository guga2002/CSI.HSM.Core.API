using GuestSide.Core.Entities.Notification;

namespace GuestSide.Application.DTOs.Response.Notification
{
    public class StafNotificationResponseDto
    {
        public long Id { get; set; }

        public long StaffId { get; set; }

        public long NotificationId { get; set; }

        public NotificationResponseDto Notification { get; set; }
    }
}
