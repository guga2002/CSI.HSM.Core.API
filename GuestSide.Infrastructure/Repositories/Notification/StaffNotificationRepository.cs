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
        public async override Task<StaffNotification> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await Context.StaffNotifications.Include(io=>io.Notifications).Where(io=>io.Id==(long)id).FirstOrDefaultAsync()??
                throw new ArgumentNullException("no records found on this id");
        }
        public async override Task<IEnumerable<StaffNotification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Context.StaffNotifications.Include(io => io.Notifications).ToListAsync();
        }
    }
}
