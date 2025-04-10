using Domain.Core.Entities.Item;
using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Item
{
    public interface IItemCategoryToStaffCategoryRepository : IGenericRepository<ItemCategoryToStaffCategory>
    {
        Task<IEnumerable<ItemCategoryToStaffCategory>> GetByItemCategoryAsync(long itemCategoryId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ItemCategoryToStaffCategory>> GetByStaffCategoryAsync(long staffCategoryId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ItemCategoryToStaffCategory>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default);

        Task<bool> AddMappingAsync(long itemCategoryId, long staffCategoryId, CancellationToken cancellationToken = default);
        Task<bool> RemoveMappingAsync(long mappingId, CancellationToken cancellationToken = default);

        Task<int> CountItemCategoriesMappedToStaffAsync(CancellationToken cancellationToken = default);
        Task<int> CountStaffCategoriesMappedToItemsAsync(CancellationToken cancellationToken = default);
    }
}