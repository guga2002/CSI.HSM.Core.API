using Domain.Core.Entities.Room;
using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Room
{
    public interface IRoomCategoryRepository : IGenericRepository<RoomCategory>
    {
        Task<RoomCategory?> GetCategoryByName(string categoryName);
        Task<IEnumerable<RoomCategory>> GetAllActiveCategories();
        Task<bool> UpdateRoomCategoryName(long categoryId, string newName);
    }
}