using Core.Core.Data;
using Core.Core.Entities.Notification;
using Core.Core.Interfaces.Notification;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Notification
{
    public class StaffNotificationRepository : GenericRepository<StaffNotification>, IStaffNotificationRepository
    {
        public StaffNotificationRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<StaffNotification> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public async override Task<StaffNotification> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await Context.StaffNotifications.Include(io => io.Notifications).Where(io => io.Id == (long)id).FirstOrDefaultAsync() ??
                throw new ArgumentNullException("no records found on this id");
        }
        public async override Task<IEnumerable<StaffNotification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Context.StaffNotifications.Include(io => io.Notifications).ToListAsync();
        }
    }
}
