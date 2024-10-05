using GuestSide.Core.Data;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.Room;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Room
{
    public class RoomCategoryRepository : GenericRepository<RoomCategory>, IRoomCategoryRepository
    {
        public RoomCategoryRepository(GuestSideDb context) : base(context)
        {
        }
    }
}
