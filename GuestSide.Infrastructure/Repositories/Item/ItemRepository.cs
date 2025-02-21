using Core.Core.Data;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.Item;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Item
{
    public class ItemsRepository : GenericRepository<Items>, IItemsRepository
    {
        private readonly GuestSideDb _context;
        private readonly IRedisCash _redisCache;
        private readonly ILogger<Items> _logger;

        public ItemsRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Items> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
            _context = context;
            _redisCache = redisCache;
            _logger = logger;
        }

        #region Item Lookup & Filtering
        public async Task<IEnumerable<Items>> GetItemsByCategoryAsync(long categoryId, CancellationToken cancellationToken = default)
        {
            return await _context.Items.AsNoTracking()
                .Where(item => item.ItemCategoryId == categoryId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Items>> GetItemsByLanguageAsync(string languageCode, CancellationToken cancellationToken = default)
        {
            return await _context.Items.AsNoTracking()
                .Where(item => item.LanguageCode == languageCode)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Items>> GetOrderableItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Items.AsNoTracking()
                .Where(item => item.IsOrderAble)
                .ToListAsync(cancellationToken);
        }

        //public async Task<IEnumerable<Items>> GetOutOfStockItemsAsync(CancellationToken cancellationToken = default)
        //{
        //    return await _context.Items.AsNoTracking()
        //        .Where(item => item.Quantity == 0)
        //        .ToListAsync(cancellationToken);
        //}
        #endregion

        #region Item Management
        //public async Task<bool> UpdateItemQuantityAsync(long itemId, int newQuantity, CancellationToken cancellationToken = default)
        //{
        //    var item = await _context.Items.FindAsync(new object[] { itemId }, cancellationToken);
        //    if (item == null) return false;

        //    item.Quantity = newQuantity;
        //    await _context.SaveChangesAsync(cancellationToken);

        //    await InvalidateCache(itemId);
        //    return true;
        //}

        public async Task<bool> UpdateItemPriceAsync(long itemId, decimal newPrice, CancellationToken cancellationToken = default)
        {
            var item = await _context.Items.FindAsync(new object[] { itemId }, cancellationToken);
            if (item == null) return false;

            item.Price = newPrice;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(itemId);
            return true;
        }

        public async Task<bool> SetItemOrderableStatusAsync(long itemId, bool isOrderable, CancellationToken cancellationToken = default)
        {
            var item = await _context.Items.FindAsync(new object[] { itemId }, cancellationToken);
            if (item == null) return false;

            item.IsOrderAble = isOrderable;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(itemId);
            return true;
        }
        #endregion

        #region Inventory Analytics
        public async Task<int> CountItemsInCategoryAsync(long categoryId, CancellationToken cancellationToken = default)
        {
            return await _context.Items
                .Where(item => item.ItemCategoryId == categoryId)
                .CountAsync(cancellationToken);
        }

        public async Task<int> CountOrderableItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Items
                .Where(item => item.IsOrderAble)
                .CountAsync(cancellationToken);
        }
        #endregion

        #region Caching Helpers
        private async Task<bool> InvalidateCache(long itemId)
        {
            var cacheKey = $"Items_GetById_{itemId}";
            try
            {
                await _redisCache.RemoveCache(cacheKey);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error invalidating cache for key {CacheKey}", cacheKey);
                return false;
            }
        }
        #endregion
    }
}
