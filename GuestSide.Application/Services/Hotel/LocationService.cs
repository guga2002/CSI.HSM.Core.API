using AutoMapper;
using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Application.Interface.Hotel;
using GuestSide.Core.Entities.Hotel.GeoLocation;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Hotel;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Hotel;

public class LocationService : GenericService<LocationrequestDto, LocationResponse, long, GuestSide.Core.Entities.Hotel.GeoLocation.Location>, ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;
    public LocationService(ILocationRepository locationRepository,IMapper mapper, IGenericRepository<Location> repository, ILogger<GenericService<LocationrequestDto, LocationResponse, long, Location>> logger) : base(mapper, repository, logger)
    {
        _locationRepository=locationRepository;
        _mapper = mapper;
    }

    public async Task<LocationResponse> GetLocationByHotelId(long hotelId, CancellationToken token = default)
    {
        return await _locationRepository.GetLocationByHotelId(hotelId, token).ContinueWith(io => _mapper.Map<LocationResponse>(io.Result), token);
    }
}
