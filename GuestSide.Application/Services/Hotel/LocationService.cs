using AutoMapper;
using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Application.Interface.Hotel;
using GuestSide.Core.Entities.Hotel.GeoLocation;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Hotel
{
    public class LocationService : GenericService<LocationrequestDto, LocationResponse, long, GuestSide.Core.Entities.Hotel.GeoLocation.Location>, ILocationService
    {
        public LocationService(IMapper mapper, IGenericRepository<Location> repository, ILogger<GenericService<LocationrequestDto, LocationResponse, long, Location>> logger) : base(mapper, repository, logger)
        {
        }
    }
}
