using Core.Core.Data;
using Core.Core.Entities.Room;
using Core.Core.Interfaces.Room;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Room
{
    public class RoomRepository : GenericRepository<Core.Entities.Room.Room>, IRoomRepository
    {
        public RoomRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Core.Entities.Room.Room> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public async Task<Core.Entities.Room.Room> GetRoomDetails(long roomId)
        {
            var res = await DbSet.Where(io => io.Id == roomId).Include(io => io.RoomCategory).FirstOrDefaultAsync();

            return res;
        }

        public async Task<Core.Entities.Hotel.Hotel> GetHotelForRoom(long roomId)
        {
            var res = await DbSet.Where(io => io.Id == roomId).Include(io => io.Hotel).ThenInclude(io => io.Location).Select(io => io.Hotel).FirstOrDefaultAsync();

            return res;
        }

    }
}
