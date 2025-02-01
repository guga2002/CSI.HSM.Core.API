using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.Notification;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.Notification;

public class GuestNotificationRepository : GenericRepository<GuestNotification>, IGuestNotificationRepository
{
    public GuestNotificationRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<GuestNotification> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }

    public async Task<GuestNotification> MarkGuestNotificationAsRead(long GuestId, long NotificationId,bool unread=false)
    {
        var sms = await DbSet.Where(io => io.GuestId == GuestId && io.NotificationId == NotificationId).FirstOrDefaultAsync();

        if (sms is not null)
        {
            if (unread)
            {
                sms.IsRead = false;
            }
            else
            {
                sms.IsRead = true;
            }
            await Context.SaveChangesAsync();
            return sms;
        }
        return null;
    }

    public async Task<IEnumerable<GuestNotification>>GetNotificationsByGuestId(long GuestId)
    {
        return await DbSet.Where(io=>io.GuestId==GuestId).ToListAsync();
    }

    public override async Task<IEnumerable<GuestNotification>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.Include(io=>io.Guest).Include(io=>io.Notifications).ToListAsync();
    }

    public override async Task<GuestNotification> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        return await DbSet.Include(io => io.Guest).Include(io => io.Notifications).Where(io => io.IsActive && io.Id == long.Parse(id.ToString())).FirstOrDefaultAsync();
    }
}
