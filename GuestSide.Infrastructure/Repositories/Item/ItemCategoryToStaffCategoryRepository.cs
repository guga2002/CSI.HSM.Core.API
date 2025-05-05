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
    public class ItemCategoryToStaffCategoryRepository : GenericRepository<ItemCategoryToStaffCategory>, IItemCategoryToStaffCategoryRepository
    {
        private readonly CoreSideDb _context;
        private readonly IRedisCash _redisCache;
        private readonly ILogger<ItemCategoryToStaffCategory> _logger;

        public ItemCategoryToStaffCategoryRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<ItemCategoryToStaffCategory> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
            _context = context;
            _redisCache = redisCache;
            _logger = logger;
        }

        #region  Lookup & Filtering
        public async Task<IEnumerable<ItemCategoryToStaffCategory>> GetByItemCategoryAsync(long itemCategoryId, CancellationToken cancellationToken = default)
        {
            return await _context.ItemCategoryToStaffCategories.AsNoTracking()
                .Where(mapping => mapping.ItemCategoryId == itemCategoryId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<ItemCategoryToStaffCategory>> GetByStaffCategoryAsync(long staffCategoryId, CancellationToken cancellationToken = default)
        {
            return await _context.ItemCategoryToStaffCategories.AsNoTracking()
                .Where(mapping => mapping.StaffCategoryId == staffCategoryId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<ItemCategoryToStaffCategory>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ItemCategoryToStaffCategories.AsNoTracking()
                .Include(mapping => mapping.ItemCategory)
                .Include(mapping => mapping.StaffCategory)
                .ToListAsync(cancellationToken);
        }
        #endregion

        #region Management Operations
        public async Task<bool> AddMappingAsync(long itemCategoryId, long staffCategoryId, CancellationToken cancellationToken = default)
        {
            var mapping = new ItemCategoryToStaffCategory
            {
                ItemCategoryId = itemCategoryId,
                StaffCategoryId = staffCategoryId
            };

            await _context.ItemCategoryToStaffCategories.AddAsync(mapping, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache($"ItemCategoryToStaffCategory_GetByItem_{itemCategoryId}");
            await InvalidateCache($"ItemCategoryToStaffCategory_GetByStaff_{staffCategoryId}");
            return true;
        }

        public async Task<bool> RemoveMappingAsync(long mappingId, CancellationToken cancellationToken = default)
        {
            var mapping = await _context.ItemCategoryToStaffCategories.FindAsync(new object[] { mappingId }, cancellationToken);
            if (mapping == null) return false;

            _context.ItemCategoryToStaffCategories.Remove(mapping);
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache($"ItemCategoryToStaffCategory_GetByItem_{mapping.ItemCategoryId}");
            await InvalidateCache($"ItemCategoryToStaffCategory_GetByStaff_{mapping.StaffCategoryId}");
            return true;
        }
        #endregion

        #region Analytics & Reporting
        public async Task<int> CountItemCategoriesMappedToStaffAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ItemCategoryToStaffCategories
                .Select(mapping => mapping.ItemCategoryId)
                .Distinct()
                .CountAsync(cancellationToken);
        }

        public async Task<int> CountStaffCategoriesMappedToItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ItemCategoryToStaffCategories
                .Select(mapping => mapping.StaffCategoryId)
                .Distinct()
                .CountAsync(cancellationToken);
        }
        #endregion

        #region Caching Helpers
        private async Task<bool> InvalidateCache(string cacheKey)
        {
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
