using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Core.Entities.Hotel.GeoLocation;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Hotel;

[Route("api/[controller]")]
[ApiController]
public class LocationController : CSIControllerBase<LocationrequestDto, LocationResponse, long, GuestSide.Core.Entities.Hotel.GeoLocation.Location>
{
    public LocationController(IService<LocationrequestDto, LocationResponse, long, Location> serviceProvider, IAdditionalFeatures<LocationrequestDto, LocationResponse, long, Location> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
