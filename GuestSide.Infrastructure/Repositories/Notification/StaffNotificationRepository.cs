using GuestSide.Core.Data;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.Notification;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Notification
{
    public class StaffNotificationRepository : GenericRepository<StaffNotification>, IStaffNotificationRepository
    {
        public StaffNotificationRepository(GuestSideDb context) : base(context)
        {
        }
    }
}
