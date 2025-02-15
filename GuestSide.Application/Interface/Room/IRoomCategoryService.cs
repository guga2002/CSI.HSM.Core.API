using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Room;

namespace Core.Application.Interface.Room
{
    public interface IRoomCategoryService : IService<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory>,
        IAdditionalFeatures<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory>
    {
        /// <summary>
        /// Get category details by name.
        /// </summary>
        Task<RoomCategoryResponseDto?> GetCategoryByName(string categoryName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all active room categories.
        /// </summary>
        Task<IEnumerable<RoomCategoryResponseDto>> GetAllActiveCategories(CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the name of a room category.
        /// </summary>
        Task<bool> UpdateRoomCategoryName(long categoryId, string newName, CancellationToken cancellationToken = default);
    }
}