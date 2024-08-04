using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.Notification;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Notification
{
    public class StaffNotificationRepository : GenericRepository<StaffNotification>, IStaffNotificationRepository
    {
        public StaffNotificationRepository(DbContext context) : base(context)
        {
        }
    }
}
