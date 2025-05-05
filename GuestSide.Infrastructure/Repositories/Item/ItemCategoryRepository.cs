using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Item;
using Domain.Core.Interfaces.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Item
{
    public class ItemCategoryRepository : GenericRepository<ItemCategory>, IItemCategoryRepository
    {
        private readonly CoreSideDb _context;
        private readonly IRedisCash _redisCache;
        private readonly ILogger<ItemCategory> _logger;

        public ItemCategoryRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<ItemCategory> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
            _context = context;
            _redisCache = redisCache;
            _logger = logger;
        }

        #region Category Lookup & Filtering
        public async Task<ItemCategory?> GetCategoryByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.ItemCategories.AsNoTracking()
                .FirstOrDefaultAsync(category => category.Name == name, cancellationToken);
        }

        public async Task<IEnumerable<ItemCategory>> GetCategoriesByLanguageAsync(string languageCode, CancellationToken cancellationToken = default)
        {
            return await _context.ItemCategories.AsNoTracking()
                .Where(category => category.LanguageCode == languageCode)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<ItemCategory>> GetCategoriesWithItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ItemCategories.AsNoTracking()
                .Include(category => category.Items)
                .Where(category => category.Items.Any())
                .ToListAsync(cancellationToken);
        }
        #endregion

        #region Category Management
        public async Task<bool> UpdateCategoryNameAsync(long categoryId, string newName, CancellationToken cancellationToken = default)
        {
            var category = await _context.ItemCategories.FindAsync(new object[] { categoryId }, cancellationToken);
            if (category == null) return false;

            category.Name = newName;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(categoryId);
            return true;
        }

        public async Task<bool> UpdateCategoryDescriptionAsync(long categoryId, string newDescription, CancellationToken cancellationToken = default)
        {
            var category = await _context.ItemCategories.FindAsync(new object[] { categoryId }, cancellationToken);
            if (category == null) return false;

            category.Description = newDescription;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(categoryId);
            return true;
        }

        public async Task<bool> ChangeCategoryLanguageAsync(long categoryId, string newLanguageCode, CancellationToken cancellationToken = default)
        {
            var category = await _context.ItemCategories.FindAsync(new object[] { categoryId }, cancellationToken);
            if (category == null) return false;

            category.LanguageCode = newLanguageCode;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(categoryId);
            return true;
        }
        #endregion

        #region Category Analytics
        public async Task<int> CountTotalCategoriesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ItemCategories.CountAsync(cancellationToken);
        }

        public async Task<int> CountCategoriesWithItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ItemCategories
                .Where(category => category.Items.Any())
                .CountAsync(cancellationToken);
        }
        #endregion

        #region Caching Helpers
        private async Task<bool> InvalidateCache(long categoryId)
        {
            var cacheKey = $"ItemCategory_GetById_{categoryId}";
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
