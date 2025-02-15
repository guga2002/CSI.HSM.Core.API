using Core.Core.Data;
using Core.Core.Entities.Guest;
using Core.Core.Entities.Room;
using Core.Core.Interfaces.Guest;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Guest
{
    public class GuestRepository : GenericRepository<Guests>, IGuestRepository
    {
        public GuestRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Guests> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public async Task<Rooms> GetRoomByGuestId(long GuestId)
        {
            var res = await DbSet.Where(io => io.Id == GuestId).Include(io => io.Room).ThenInclude(io => io.QRCode).Select(io => io.Room).FirstOrDefaultAsync();
            return res;
        }
    }
}
