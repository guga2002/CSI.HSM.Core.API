using Core.Core.Data;
using Core.Core.Entities.Notification;
using Core.Core.Interfaces.Notification;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Notification
{
    public class NotificationRepository : GenericRepository<Notifications>, INotificationRepository
    {
        public NotificationRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Notifications> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
