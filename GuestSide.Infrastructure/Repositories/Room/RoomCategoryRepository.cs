using Core.Core.Data;
using Core.Core.Entities.Room;
using Core.Core.Interfaces.Room;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Room
{
    public class RoomCategoryRepository : GenericRepository<RoomCategory>, IRoomCategoryRepository
    {
        public RoomCategoryRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<RoomCategory> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
