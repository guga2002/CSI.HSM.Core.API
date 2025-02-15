using Core.Core.Data;
using Core.Core.Entities.Hotel.GeoLocation;
using Core.Core.Interfaces.Hotel;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Hotel
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Location> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public async Task<Location> GetLocationByHotelId(long hotelId, CancellationToken token = default)
        {
            var res = await DbSet.Where(io => io.HotelId == hotelId).FirstOrDefaultAsync(token);
            return res ?? throw new ArgumentNullException("No data found in database");
        }
    }
}
