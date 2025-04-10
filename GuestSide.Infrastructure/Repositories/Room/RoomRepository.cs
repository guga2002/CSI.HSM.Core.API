using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Interfaces.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Room
{
    public class RoomRepository : GenericRepository<Domain.Core.Entities.Room.Room>, IRoomRepository
    {
        public RoomRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Domain.Core.Entities.Room.Room> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        #region Get Available Rooms
        public async Task<IEnumerable<Domain.Core.Entities.Room.Room>> GetAvailableRooms(long hotelId, long categoryId, int maxOccupancy, decimal maxPrice)
        {
            return await DbSet
                .Where(room => room.HotelId == hotelId
                            && room.RoomCategoryId == categoryId
                            && room.IsAvailable
                            && room.MaxOccupancy == maxOccupancy
                            && room.PricePerNight <= maxPrice)
                .OrderBy(room => room.PricePerNight)
                .ToListAsync();
        }
        #endregion

        #region Mark Room as Unavailable
        public async Task<bool> MarkRoomAsUnavailable(long roomId)
        {
            var room = await DbSet.FindAsync(roomId);
            if (room == null || !room.IsAvailable) return false;

            room.IsAvailable = false;
            room.UpdatedAt = DateTime.UtcNow;
            await Context.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Update Room Price
        public async Task<bool> UpdateRoomPrice(long roomId, decimal newPrice)
        {
            var room = await DbSet.FindAsync(roomId);
            if (room == null) return false;

            room.PricePerNight = newPrice;
            room.UpdatedAt = DateTime.UtcNow;
            await Context.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Get Rooms by Hotel
        public async Task<IEnumerable<Domain.Core.Entities.Room.Room>> GetRoomsByHotel(long hotelId)
        {
            return await DbSet
                .Where(room => room.HotelId == hotelId)
                .OrderBy(room => room.RoomNumber)
                .ToListAsync();
        }
        #endregion

        public async Task<Domain.Core.Entities.Hotel.Hotel> GetHotelForRoomAsync(long roomId)
        {
           return await DbSet.Include(io=>io.Hotel).Where(io => io.Id == roomId).Select(io => io.Hotel).FirstOrDefaultAsync();
        }

    }
}
