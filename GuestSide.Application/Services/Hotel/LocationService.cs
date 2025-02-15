using AutoMapper;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.Interface.Hotel;
using Core.Core.Entities.Hotel.GeoLocation;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.UniteOfWork;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Hotel;

public class LocationService : GenericService<LocationrequestDto, LocationResponse, long, Location>, ILocationService
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
