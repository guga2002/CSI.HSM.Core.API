using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Item;

namespace Core.Application.Interface.Item
{
    public interface IItemService : IService<ItemDto, ItemResponseDto, long, Items>,
        IAdditionalFeatures<ItemDto, ItemResponseDto, long, Items>
    {
        /// <summary>
        /// Get items by category.
        /// </summary>
        Task<IEnumerable<ItemResponseDto>> GetItemsByCategoryAsync(long categoryId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get items by language code.
        /// </summary>
        Task<IEnumerable<ItemResponseDto>> GetItemsByLanguageAsync(string languageCode, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all orderable items.
        /// </summary>
        Task<IEnumerable<ItemResponseDto>> GetOrderableItemsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get out-of-stock items.
        /// </summary>
        Task<IEnumerable<ItemResponseDto>> GetOutOfStockItemsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the quantity of an item.
        /// </summary>
        Task<bool> UpdateItemQuantityAsync(long itemId, int newQuantity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the price of an item.
        /// </summary>
        Task<bool> UpdateItemPriceAsync(long itemId, decimal newPrice, CancellationToken cancellationToken = default);

        /// <summary>
        /// Set an item's orderable status.
        /// </summary>
        Task<bool> SetItemOrderableStatusAsync(long itemId, bool isOrderable, CancellationToken cancellationToken = default);

        /// <summary>
        /// Count the number of items in a category.
        /// </summary>
        Task<int> CountItemsInCategoryAsync(long categoryId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Count the number of orderable items.
        /// </summary>
        Task<int> CountOrderableItemsAsync(CancellationToken cancellationToken = default);
    }
}
