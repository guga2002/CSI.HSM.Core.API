using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.Notification;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.Notification
{
    public class GuestNotificationRepository : GenericRepository<GuestNotification>, IGuestNotificationRepository
    {
        public GuestNotificationRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<GuestNotification> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
