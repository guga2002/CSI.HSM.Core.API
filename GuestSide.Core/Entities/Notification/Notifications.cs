using GuestSide.Core.Entities.AbstractEntities;

namespace GuestSide.Core.Entities.Notification
{
    public class Notifications:AbstractEntity
    {
        public required string Title { get; set; }

        public required string Message { get; set; }

        public DateTime NotificationDate { get; set; }

        public bool IsRead { get; set; }

        public IEnumerable<StaffNotification> StaffNotifications { get; set; }

        public IEnumerable<GuestNotification> GuestNotifications { get; set; }
    }
}
