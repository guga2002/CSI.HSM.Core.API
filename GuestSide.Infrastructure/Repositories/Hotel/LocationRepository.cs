using GuestSide.Core.Data;
using GuestSide.Core.Interfaces.Hotel;
using GuestSide.Infrastructure.Repositories.AbstractRepository;

namespace GuestSide.Infrastructure.Repositories.Hotel
{
    public class LocationRepository : GenericRepository<GuestSide.Core.Entities.Hotel.GeoLocation.Location>, ILocationRepository
    {
        public LocationRepository(GuestSideDb context) : base(context)
        {
        }
    }
}
