using Domain.Core.Entities.Guest;
using Domain.Core.Interfaces.AbstractInterface;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Guest
{
    public interface IGuestRepository : IGenericRepository<Guests>
    {
        Task<Entities.Room.Room> GetRoomByGuestIdAsync(long guestId);
        Task<Guests> GetGuestDetailsByIdAsync(long guestId);
        Task<IEnumerable<Guests>> GetGuestsByRoomIdAsync(long roomId);
        Task<bool> CheckGuestExistsAsync(string email, string phoneNumber);
        Task<bool> UpdateGuestStatusAsync(long guestId, long statusId);
        Task<IEnumerable<Guests>> GetFrequentGuestsAsync();
        Task<bool> AssignRoomToGuestAsync(long guestId, long roomId);
        Task<bool> DeleteGuestPermanentlyAsync(long guestId);
        Task<IEnumerable<Entities.Room.Room>> RoomByGuestIdAsync(long GuestId);
    }
}