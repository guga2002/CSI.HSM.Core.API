using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.Room;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.Room
{
    public class RoomRepository : GenericRepository<Rooms>, IRoomRepository
    {
        public RoomRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Rooms> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public async Task<Rooms> GetRoomDetails(long roomId)
        {
            var res=await DbSet.Where(io => io.Id == roomId).Include(io => io.RoomCategory).FirstOrDefaultAsync();

            return res;
        }

        public async Task<Core.Entities.Hotel.Hotel> GetHotelForRoom(long roomId)
        {
            var res = await DbSet.Where(io => io.Id == roomId).Include(io => io.Hotel).ThenInclude(io=>io.Location).Select(io => io.Hotel).FirstOrDefaultAsync();

            return res;
        }

    }
}
