using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.AbstractInterface;

namespace GuestSide.Core.Interfaces.Room
{
    public interface IRoomRepository:IGenericRepository<Rooms>
    {
        Task<Core.Entities.Hotel.Hotel> GetHotelForRoom(long roomId);
        Task<Rooms> GetRoomDetails(long roomId);
        //add another method
    }
}
