using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Room
{
    public interface IRoomRepository : IGenericRepository<Entities.Room.Room>
    {
        Task<IEnumerable<Entities.Room.Room>> GetAvailableRooms(long hotelId, long categoryId, int maxOccupancy, decimal maxPrice);
        Task<bool> MarkRoomAsUnavailable(long roomId);
        Task<bool> UpdateRoomPrice(long roomId, decimal newPrice);
        Task<IEnumerable<Entities.Room.Room>> GetRoomsByHotel(long hotelId);
        Task<Entities.Hotel.Hotel> GetHotelForRoomAsync(long roomId);
    }
}