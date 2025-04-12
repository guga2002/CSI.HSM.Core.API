using AutoMapper;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.Interface.Hotel;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Hotel;
using Domain.Core.Interfaces.UniteOfWork;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Hotel.Service;

public class HotelService : GenericService<HotelRequestDto, HotelResponse, long, Domain.Core.Entities.Hotel.Hotel>, IHotelService
{
    private readonly IUniteOfWork _uniteOfWork;
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<HotelService> _logger;

    public HotelService(
        IMapper mapper,
        IHotelRepository hotelRepository,
        IUniteOfWork uniteOfWork,
        ILogger<HotelService> logger,
        IGenericRepository<Domain.Core.Entities.Hotel.Hotel> repository,
        IAdditionalFeaturesRepository<Domain.Core.Entities.Hotel.Hotel> additionalFeatures)
        : base(mapper, repository, logger, additionalFeatures)
    {
        _uniteOfWork = uniteOfWork;
        _hotelRepository = hotelRepository;
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

    private void ValidateStarRating(int stars)
    {
        if (stars is < 1 or > 5)
        {
            _logger.LogWarning("Invalid star rating: {Stars}", stars);
            throw new ArgumentException("Star rating must be between 1 and 5.");
        }
    }

    private void ValidateString(string? value, string paramName)
    {
        if (!string.IsNullOrWhiteSpace(value) && value.Length < 3)
        {
            _logger.LogWarning("{ParameterName} must be at least 3 characters long.", paramName);
            throw new ArgumentException($"{paramName} must be at least 3 characters long.");
        }
    }

    public async Task<IEnumerable<HotelResponse>> GetAllHotelsAsync(CancellationToken cancellationToken = default)
    {
        var hotels = await _hotelRepository.GetAllHotelsAsync();
        return _mapper.Map<IEnumerable<HotelResponse>>(hotels);
    }

    public async Task<HotelResponse?> GetHotelById(long hotelId, CancellationToken cancellationToken = default)
    {
        ValidatePositiveId(hotelId, nameof(hotelId));

        var hotel = await _hotelRepository.GetHotelById(hotelId);
        return hotel is null ? null : _mapper.Map<HotelResponse>(hotel);
    }

    public async Task<IEnumerable<HotelResponse>> GetHotelsByCity(string city, CancellationToken cancellationToken = default)
    {
        ValidateString(city, nameof(city));

        var hotels = await _hotelRepository.GetHotelsByCity(city);
        return _mapper.Map<IEnumerable<HotelResponse>>(hotels);
    }

    public async Task<IEnumerable<HotelResponse>> GetHotelsByStars(int stars, CancellationToken cancellationToken = default)
    {
        ValidateStarRating(stars);

        var hotels = await _hotelRepository.GetHotelsByStars(stars);
        return _mapper.Map<IEnumerable<HotelResponse>>(hotels);
    }

    public async Task<bool> UpdateHotelDetails(long hotelId, string? description, List<string>? pictures, List<string>? facilities, CancellationToken cancellationToken = default)
    {
        ValidatePositiveId(hotelId, nameof(hotelId));

        var hotel = await _hotelRepository.GetHotelById(hotelId);
        if (hotel is null)
        {
            _logger.LogWarning("Hotel with ID {HotelId} does not exist.", hotelId);
            throw new ArgumentException($"Hotel with ID {hotelId} does not exist.");
        }

        ValidateString(description, nameof(description));

        var result = await _hotelRepository.UpdateHotelDetails(hotelId, description, pictures, facilities);
        if (result)
        {
            await _uniteOfWork.Savechanges(); // Ensure transaction consistency
            //await _uniteOfWork.CommitTransaction();
        }

        return result;
    }

    public async Task<HotelResponse?> GetFullHotelDetails(long hotelId, CancellationToken cancellationToken = default)
    {
        ValidatePositiveId(hotelId, nameof(hotelId));

        var hotel = await _hotelRepository.GetFullHotelDetails(hotelId);
        return hotel is null ? null : _mapper.Map<HotelResponse>(hotel);
    }
}
