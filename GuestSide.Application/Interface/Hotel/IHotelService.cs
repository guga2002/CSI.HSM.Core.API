using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Hotel;

public interface IHotelService : IService<HotelRequestDto, HotelResponse, long, Domain.Core.Entities.Hotel.Hotel>,
    IAdditionalFeatures<HotelRequestDto, HotelResponse, long, Domain.Core.Entities.Hotel.Hotel>
{
    /// <summary>
    /// Get all hotels.
    /// </summary>
    Task<IEnumerable<HotelResponse>> GetAllHotelsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get hotel by ID.
    /// </summary>
    Task<HotelResponse?> GetHotelById(long hotelId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get hotels in a specific city.
    /// </summary>
    Task<IEnumerable<HotelResponse>> GetHotelsByCity(string city, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get hotels by star rating (1-5 stars).
    /// </summary>
    Task<IEnumerable<HotelResponse>> GetHotelsByStars(int stars, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update hotel details (address, description, pictures, facilities).
    /// </summary>
    Task<bool> UpdateHotelDetails(long hotelId, string? description, List<string>? pictures, List<string>? facilities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get full hotel details, including rooms and services.
    /// </summary>
    Task<HotelResponse?> GetFullHotelDetails(long hotelId, CancellationToken cancellationToken = default);
}