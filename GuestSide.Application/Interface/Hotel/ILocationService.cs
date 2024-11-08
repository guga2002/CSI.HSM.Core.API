using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Core.Entities.Hotel.GeoLocation;

namespace GuestSide.Application.Interface.Hotel
{
    public interface ILocationService: IService<LocationrequestDto, LocationResponse, long, GuestSide.Core.Entities.Hotel.GeoLocation.Location>
    {
        Task<LocationResponse> GetLocationByHotelId(long hotelId, CancellationToken token = default);
    }
}
