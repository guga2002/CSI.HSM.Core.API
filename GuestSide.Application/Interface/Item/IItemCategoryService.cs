using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Domain.Core.Entities.Item;

namespace Core.Application.Interface.Item
{
    public interface IItemCategoryService : IService<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory>,
        IAdditionalFeatures<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory>
    {
        /// <summary>
        /// Get an item category by name.
        /// </summary>
        Task<ItemCategoryResponseDto?> GetCategoryByNameAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get item categories by language.
        /// </summary>
        Task<IEnumerable<ItemCategoryResponseDto>> GetCategoriesByLanguageAsync(string languageCode, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all item categories that contain items.
        /// </summary>
        Task<IEnumerable<ItemCategoryResponseDto>> GetCategoriesWithItemsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the name of a category.
        /// </summary>
        Task<bool> UpdateCategoryNameAsync(long categoryId, string newName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the description of a category.
        /// </summary>
        Task<bool> UpdateCategoryDescriptionAsync(long categoryId, string newDescription, CancellationToken cancellationToken = default);

        /// <summary>
        /// Change the language of a category.
        /// </summary>
        Task<bool> ChangeCategoryLanguageAsync(long categoryId, string newLanguageCode, CancellationToken cancellationToken = default);

        /// <summary>
        /// Count total categories.
        /// </summary>
        Task<int> CountTotalCategoriesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Count categories that have associated items.
        /// </summary>
        Task<int> CountCategoriesWithItemsAsync(CancellationToken cancellationToken = default);
    }
}
