using Common.Data.Entities.Guest;
using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Guest
{
    public interface IGuestService : IService<GuestDto, GuestResponseDto, long, Guests>,
        IAdditionalFeatures<GuestDto, GuestResponseDto, long, Guests>
    {
        /// <summary>
        /// Get room details by guest ID.
        /// </summary>
        Task<RoomsResponseDto?> GetRoomByGuestIdAsync(long guestId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get detailed information about a guest.
        /// </summary>
        Task<GuestResponseDto?> GetGuestDetailsByIdAsync(long guestId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all guests assigned to a specific room.
        /// </summary>
        Task<IEnumerable<GuestResponseDto>> GetGuestsByRoomIdAsync(long roomId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Check if a guest exists based on email and phone number.
        /// </summary>
        Task<bool> CheckGuestExistsAsync(string email, string phoneNumber, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the status of a guest.
        /// </summary>
        Task<bool> UpdateGuestStatusAsync(long guestId, long statusId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a list of frequent guests.
        /// </summary>
        Task<IEnumerable<GuestResponseDto>> GetFrequentGuestsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assign a guest to a room.
        /// </summary>
        Task<bool> AssignRoomToGuestAsync(long guestId, long roomId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Permanently delete a guest from the system.
        /// </summary>
        Task<bool> DeleteGuestPermanentlyAsync(long guestId, CancellationToken cancellationToken = default);

        Task<IEnumerable<RoomsResponseDto>> RoomByGuestIdAsync(long GuestId);
    }
}
