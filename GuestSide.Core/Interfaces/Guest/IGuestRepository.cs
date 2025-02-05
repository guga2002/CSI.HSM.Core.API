using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.AbstractInterface;

namespace GuestSide.Core.Interfaces.Guest
{
    public interface IGuestRepository : IGenericRepository<Guests>
    {
        Task<Rooms> GetRoomByGuestId(long GuestId);
        //add another methods
    }
}
