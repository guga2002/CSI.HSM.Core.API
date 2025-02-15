using Core.Core.Entities.Hotel.GeoLocation;
using Core.Core.Interfaces.AbstractInterface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Core.Interfaces.Hotel
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        Task<IEnumerable<Location>> GetAllLocationsAsync();
        Task<Location?> GetLocationByHotelId(long hotelId);
        Task<Location?> FindNearestHotel(double latitude, double longitude);
        Task<bool> UpdateHotelLocation(long hotelId, double latitude, double longitude);
    }
}