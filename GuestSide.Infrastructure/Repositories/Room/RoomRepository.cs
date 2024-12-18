using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.Room;
using GuestSide.Infrastructure.Repositories.AbstractRepository;

namespace GuestSide.Infrastructure.Repositories.Room
{
    public class RoomRepository : GenericRepository<Rooms>, IRoomRepository
    {
        public RoomRepository(GuestSideDb context, IRedisCash redisCache) : base(context, redisCache)
        {
        }
    }
}
