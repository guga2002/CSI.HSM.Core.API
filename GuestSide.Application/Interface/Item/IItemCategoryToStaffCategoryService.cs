using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Item;

namespace Core.Application.Interface.Item
{
    public interface IItemCategoryToStaffCategoryService :
        IService<ItemCategoryToStaffCategoryDto, ItemCategoryToStaffCategoryResponseDto, long, ItemCategoryToStaffCategory>,
        IAdditionalFeatures<ItemCategoryToStaffCategoryDto, ItemCategoryToStaffCategoryResponseDto, long, ItemCategoryToStaffCategory>
    {
        /// <summary>
        /// Get mappings by item category ID.
        /// </summary>
        Task<IEnumerable<ItemCategoryToStaffCategoryResponseDto>> GetByItemCategoryAsync(long itemCategoryId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get mappings by staff category ID.
        /// </summary>
        Task<IEnumerable<ItemCategoryToStaffCategoryResponseDto>> GetByStaffCategoryAsync(long staffCategoryId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all mappings with details.
        /// </summary>
        Task<IEnumerable<ItemCategoryToStaffCategoryResponseDto>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Add a new item category to staff category mapping.
        /// </summary>
        Task<bool> AddMappingAsync(long itemCategoryId, long staffCategoryId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove an existing mapping.
        /// </summary>
        Task<bool> RemoveMappingAsync(long mappingId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Count the number of item categories mapped to staff categories.
        /// </summary>
        Task<int> CountItemCategoriesMappedToStaffAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Count the number of staff categories mapped to item categories.
        /// </summary>
        Task<int> CountStaffCategoriesMappedToItemsAsync(CancellationToken cancellationToken = default);
    }
}
