using Core.Core.Entities.Hotel.GeoLocation;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Hotel
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        Task<Location> GetLocationByHotelId(long hotelId, CancellationToken token = default);
    }
}
