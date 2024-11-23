using GuestSide.Core.Entities.Hotel.GeoLocation;
using GuestSide.Core.Interfaces.AbstractInterface;

namespace GuestSide.Core.Interfaces.Hotel
{
    public interface ILocationRepository:IGenericRepository<GuestSide.Core.Entities.Hotel.GeoLocation.Location>
    {
        Task<Location> GetLocationByHotelId(long hotelId,CancellationToken token=default);
    }
}
