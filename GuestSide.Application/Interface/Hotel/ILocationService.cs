using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;

namespace GuestSide.Application.Interface.Hotel
{
    public interface ILocationService: IService<LocationrequestDto, LocationResponse, long, GuestSide.Core.Entities.Hotel.GeoLocation.Location>
    {
    }
}
