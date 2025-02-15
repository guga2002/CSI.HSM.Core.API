using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Item
{
    public interface IItemCategoryRepository : IGenericRepository<ItemCategory>
    {
        Task<ItemCategory?> GetCategoryByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<IEnumerable<ItemCategory>> GetCategoriesByLanguageAsync(string languageCode, CancellationToken cancellationToken = default);
        Task<IEnumerable<ItemCategory>> GetCategoriesWithItemsAsync(CancellationToken cancellationToken = default);

        Task<bool> UpdateCategoryNameAsync(long categoryId, string newName, CancellationToken cancellationToken = default);
        Task<bool> UpdateCategoryDescriptionAsync(long categoryId, string newDescription, CancellationToken cancellationToken = default);
        Task<bool> ChangeCategoryLanguageAsync(long categoryId, string newLanguageCode, CancellationToken cancellationToken = default);

        Task<int> CountTotalCategoriesAsync(CancellationToken cancellationToken = default);
        Task<int> CountCategoriesWithItemsAsync(CancellationToken cancellationToken = default);
    }
}