using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.Notification;
using GuestSide.Infrastructure.Repositories.AbstractRepository;

namespace GuestSide.Infrastructure.Repositories.Notification
{
    public class NotificationRepository : GenericRepository<Notifications>, INotificationRepository
    {
        public NotificationRepository(GuestSideDb context, IRedisCash redisCache) : base(context, redisCache)
        {
        }
    }
}
