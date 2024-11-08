using GuestSide.Core.Data;
using GuestSide.Core.Entities.Hotel.GeoLocation;
using GuestSide.Core.Interfaces.Hotel;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Hotel
{
    public class LocationRepository : GenericRepository<GuestSide.Core.Entities.Hotel.GeoLocation.Location>, ILocationRepository
    {
        public LocationRepository(GuestSideDb context) : base(context)
        {
        }

        public async Task<Location> GetLocationByHotelId(long hotelId, CancellationToken token=default)
        {
            var res=await DbSet.Where(io => io.HotelId == hotelId).FirstOrDefaultAsync(token);
            return res??throw new ArgumentNullException("No data found in database");
        }
    }
}
