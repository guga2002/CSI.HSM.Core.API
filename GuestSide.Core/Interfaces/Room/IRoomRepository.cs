using Core.Core.Entities.Room;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Room
{
    public interface IRoomRepository : IGenericRepository<Entities.Room.Room>
    {
        Task<Entities.Hotel.Hotel> GetHotelForRoom(long roomId);
        Task<Entities.Room.Room> GetRoomDetails(long roomId);
        //add another method
    }
}
