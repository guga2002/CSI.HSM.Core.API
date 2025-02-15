using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Hotel.GeoLocation;

namespace Core.Application.Interface.Hotel;

public interface ILocationService : IService<LocationrequestDto, LocationResponse, long, Location>,
    IAdditionalFeatures<LocationrequestDto, LocationResponse, long, Location>
{
    Task<LocationResponse> GetLocationByHotelId(long hotelId, CancellationToken token = default);
}
