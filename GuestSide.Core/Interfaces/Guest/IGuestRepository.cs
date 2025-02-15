using Core.Core.Entities.Guest;
using Core.Core.Entities.Room;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Guest
{
    public interface IGuestRepository : IGenericRepository<Guests>
    {
        Task<Entities.Room.Room> GetRoomByGuestId(long GuestId);
        //add another methods
    }
}
