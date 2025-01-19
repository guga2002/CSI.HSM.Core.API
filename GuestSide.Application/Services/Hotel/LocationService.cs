using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.UniteOfWork;
using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Application.Interface.Hotel;
using GuestSide.Core.Entities.Hotel.GeoLocation;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Hotel;

public class LocationService : GenericService<LocationrequestDto, LocationResponse, long, GuestSide.Core.Entities.Hotel.GeoLocation.Location>, ILocationService
{
    private readonly IUniteOfWork _uniteOfWork;
    private readonly IMapper map;

    public LocationService(IMapper mapper, 
        IGenericRepository<Location> repository, ILogger<GenericService<LocationrequestDto, LocationResponse, long, Location>> logger, IAdditionalFeaturesRepository<Location> additioalFeatures, IUniteOfWork uniteOfWork, IMapper map) : base(mapper, repository, logger, additioalFeatures)
    {
        _uniteOfWork = uniteOfWork;
        this.map = map;
    }

    public async Task<LocationResponse> GetLocationByHotelId(long hotelId, CancellationToken token = default)
    {
        return await _uniteOfWork.LocationRepository.GetLocationByHotelId(hotelId, token).ContinueWith(io => map.Map<LocationResponse>(io.Result), token);
    }
}
