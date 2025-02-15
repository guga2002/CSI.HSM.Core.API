using Core.Core.Entities.Room;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Room
{
    public interface IRoomRepository : IGenericRepository<Rooms>
    {
        Task<Entities.Hotel.Hotel> GetHotelForRoom(long roomId);
        Task<Rooms> GetRoomDetails(long roomId);
        //add another method
    }
}
