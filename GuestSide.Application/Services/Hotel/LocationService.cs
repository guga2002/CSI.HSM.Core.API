using AutoMapper;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.Interface.Hotel;
using Core.Core.Entities.Hotel.GeoLocation;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Hotel;
using Core.Core.Interfaces.UniteOfWork;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Hotel
{
    public class LocationService : GenericService<LocationrequestDto, LocationResponse, long, Location>, ILocationService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<LocationService> _logger;

        public LocationService(
            IMapper mapper,
            ILocationRepository locationRepository,
            IUniteOfWork uniteOfWork,
            ILogger<LocationService> logger,
            IGenericRepository<Location> repository,
            IAdditionalFeaturesRepository<Location> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _uniteOfWork = uniteOfWork;
            _locationRepository = locationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        private void ValidatePositiveId(long id, string paramName)
        {
            if (id <= 0)
            {
                _logger.LogWarning("{ParameterName} must be a positive number.", paramName);
                throw new ArgumentException($"{paramName} must be greater than zero.", paramName);
            }
        }

        private void ValidateCoordinates(double latitude, double longitude)
        {
            if (latitude < -90 || latitude > 90)
            {
                _logger.LogWarning("Invalid latitude value: {Latitude}", latitude);
                throw new ArgumentException("Latitude must be between -90 and 90 degrees.");
            }

            if (longitude < -180 || longitude > 180)
            {
                _logger.LogWarning("Invalid longitude value: {Longitude}", longitude);
                throw new ArgumentException("Longitude must be between -180 and 180 degrees.");
            }
        }

        public async Task<IEnumerable<LocationResponse>> GetAllLocationsAsync(CancellationToken cancellationToken = default)
        {
            var locations = await _locationRepository.GetAllLocationsAsync();
            return _mapper.Map<IEnumerable<LocationResponse>>(locations);
        }

        public async Task<LocationResponse?> GetLocationByHotelId(long hotelId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(hotelId, nameof(hotelId));

            var location = await _locationRepository.GetLocationByHotelId(hotelId);
            return location is null ? null : _mapper.Map<LocationResponse>(location);
        }

        public async Task<LocationResponse?> FindNearestHotel(double latitude, double longitude, CancellationToken cancellationToken = default)
        {
            ValidateCoordinates(latitude, longitude);

            var location = await _locationRepository.FindNearestHotel(latitude, longitude);
            return location is null ? null : _mapper.Map<LocationResponse>(location);
        }

        public async Task<bool> UpdateHotelLocation(long hotelId, double latitude, double longitude, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(hotelId, nameof(hotelId));
            ValidateCoordinates(latitude, longitude);

            var existingLocation = await _locationRepository.GetLocationByHotelId(hotelId);
            if (existingLocation is null)
            {
                _logger.LogWarning("Hotel with ID {HotelId} does not have an existing location.", hotelId);
                throw new ArgumentException($"Hotel with ID {hotelId} does not have an existing location.");
            }

            if (existingLocation.Latitude == latitude && existingLocation.Longitude == longitude)
            {
                _logger.LogInformation("No changes detected in the location for hotel ID {HotelId}.", hotelId);
                return false; // No update required
            }

            var result = await _locationRepository.UpdateHotelLocation(hotelId, latitude, longitude);
            if (result)
            {
                await _uniteOfWork.Savechanges();
                await _uniteOfWork.Savechanges(); // Ensure the transaction is committed
            }

            return result;
        }
    }
}
