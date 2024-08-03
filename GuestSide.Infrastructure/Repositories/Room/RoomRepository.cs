using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.Room;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Room
{
    public class RoomRepository : GenericRepository<Rooms>, IRoomRepository
    {
        public RoomRepository(DbContext context) : base(context)
        {
        }
    }
}
