using Core.Core.Entities.Room;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Room
{
    public interface IRoomCategoryRepository : IGenericRepository<RoomCategory>
    {
        Task<RoomCategory?> GetCategoryByName(string categoryName);
        Task<IEnumerable<RoomCategory>> GetAllActiveCategories();
        Task<bool> UpdateRoomCategoryName(long categoryId, string newName);
    }
}