using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Guest;
using Domain.Core.Interfaces.Guest;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Guest
{
    public class GuestRepository : GenericRepository<Guests>, IGuestRepository
    {
        public GuestRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Guests> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        /// <summary>
        /// Get the room assigned to a specific guest
        /// </summary>
        public async Task<Domain.Core.Entities.Room.Room> GetRoomByGuestIdAsync(long guestId)
        {
            return await DbSet
                .Where(g => g.Id == guestId)
                .Include(g => g.Room)
                .ThenInclude(r => r.QRCode)
                .Select(g => g.Room)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get full guest details along with related entities
        /// </summary>
        public async Task<Guests> GetGuestDetailsByIdAsync(long guestId)
        {
            return await DbSet
                .Include(g => g.Room)
                .Include(g => g.Status)
                .Include(g => g.GuestNotifications)
                .FirstOrDefaultAsync(g => g.Id == guestId);
        }

        /// <summary>
        /// Get all guests assigned to a specific room
        /// </summary>
        public async Task<IEnumerable<Guests>> GetGuestsByRoomIdAsync(long roomId)
        {
            return await DbSet.Where(g => g.RoomId == roomId).ToListAsync();
        }

        /// <summary>
        /// Check if a guest exists by email or phone number
        /// </summary>
        public async Task<bool> CheckGuestExistsAsync(string email, string phoneNumber)
        {
            return await DbSet.AnyAsync(g => g.Email == email && g.PhoneNumber == phoneNumber);
        }

        /// <summary>
        /// Update the status of a guest
        /// </summary>
        public async Task<bool> UpdateGuestStatusAsync(long guestId, long statusId)
        {
            var guest = await DbSet.FindAsync(guestId);
            if (guest == null) return false;

            guest.StatusId = statusId;
            Context.Update(guest);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Get all guests marked as frequent
        /// </summary>
        public async Task<IEnumerable<Guests>> GetFrequentGuestsAsync()
        {
            return await DbSet.Where(g => g.IsFrequentGuest).ToListAsync();
        }

        /// <summary>
        /// Assign a new room to a guest
        /// </summary>
        public async Task<bool> AssignRoomToGuestAsync(long guestId, long roomId)
        {
            var guest = await DbSet.FindAsync(guestId);
            if (guest == null) return false;

            guest.RoomId = roomId;
            Context.Update(guest);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Permanently delete guest data from the database
        /// </summary>
        public async Task<bool> DeleteGuestPermanentlyAsync(long guestId)
        {
            var guest = await DbSet.FindAsync(guestId);
            if (guest == null) return false;

            DbSet.Remove(guest);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Domain.Core.Entities.Room.Room>> RoomByGuestIdAsync(long GuestId)
        {
            return await DbSet
                .Include(io => io.Room)
                .Where(room => room.Id == GuestId)
                .OrderBy(room => room.Room.RoomNumber)
                .Select(room => room.Room)
                .ToListAsync() ?? throw new ArgumentNullException("no data found");
        }
    }
}
