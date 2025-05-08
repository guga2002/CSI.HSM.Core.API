using Domain.Core.Entities.Item;
using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Item
{
    public interface IItemsRepository : IGenericRepository<Items>
    {
        Task<IEnumerable<Items>> GetItemsByCategoryAsync(long categoryId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Items>> GetItemsByLanguageAsync(string languageCode, CancellationToken cancellationToken = default);
        Task<IEnumerable<Items>> GetOrderableItemsAsync(CancellationToken cancellationToken = default);
        //Task<IEnumerable<Items>> GetOutOfStockItemsAsync(CancellationToken cancellationToken = default);

        //Task<bool> UpdateItemQuantityAsync(long itemId, int newQuantity, CancellationToken cancellationToken = default);
        Task<bool> UpdateItemPriceAsync(long itemId, decimal newPrice, CancellationToken cancellationToken = default);
        Task<bool> SetItemOrderableStatusAsync(long itemId, bool isOrderable, CancellationToken cancellationToken = default);

        Task<int> CountItemsInCategoryAsync(long categoryId, CancellationToken cancellationToken = default);
        //Task<int> CountOrderableItemsAsync(CancellationToken cancellationToken = default);
    }
}