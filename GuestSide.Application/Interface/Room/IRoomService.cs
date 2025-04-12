using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Room
{
    public interface IRoomService : IService<RoomsDto, RoomsResponseDto, long, Domain.Core.Entities.Room.Room>,
        IAdditionalFeatures<RoomsDto, RoomsResponseDto, long, Domain.Core.Entities.Room.Room>
    {
        /// <summary>
        /// Get available rooms by hotel and category.
        /// </summary>
        Task<IEnumerable<RoomsResponseDto>> GetAvailableRooms(long hotelId, long categoryId, int maxOccupancy, decimal maxPrice, CancellationToken cancellationToken = default);

        /// <summary>
        /// Mark a room as unavailable.
        /// </summary>
        Task<bool> MarkRoomAsUnavailable(long roomId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the price of a room.
        /// </summary>
        Task<bool> UpdateRoomPrice(long roomId, decimal newPrice, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all rooms associated with a specific hotel.
        /// </summary>
        Task<IEnumerable<RoomsResponseDto>> GetRoomsByHotel(long hotelId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get hotel by roomId
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        Task<HotelResponse> GetHotelForRoomAsync(long roomId);
    }
}