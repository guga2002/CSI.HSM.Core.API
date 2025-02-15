using Core.Core.Data;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.Staff;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Staff
{
    public class StaffCategoryRepository : GenericRepository<StaffCategory>, IStaffCategoryRepository
    {
        private readonly GuestSideDb _context;
        private readonly IRedisCash _redisCache;
        private readonly ILogger<StaffCategory> _logger;

        public StaffCategoryRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<StaffCategory> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
            _context = context;
            _redisCache = redisCache;
            _logger = logger;
        }

        #region Staff Category Lookup & Filtering
        public async Task<StaffCategory?> GetByCategoryNameAsync(string categoryName, CancellationToken cancellationToken = default)
        {
            return await _context.StaffCategories.AsNoTracking()
                .FirstOrDefaultAsync(sc => sc.CategoryName == categoryName, cancellationToken);
        }

        public async Task<IEnumerable<StaffCategory>> GetActiveCategoriesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.StaffCategories.AsNoTracking()
                .Where(sc => sc.IsActive)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffCategory>> GetInactiveCategoriesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.StaffCategories.AsNoTracking()
                .Where(sc => !sc.IsActive)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffCategory>> GetCategoriesCreatedBetweenDatesAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            return await _context.StaffCategories.AsNoTracking()
                .Where(sc => sc.CreatedAt >= startDate && sc.CreatedAt <= endDate)
                .ToListAsync(cancellationToken);
        }
        #endregion

        #region  Staff Category Management
        public async Task<bool> UpdateCategoryNameAsync(long categoryId, string newName, CancellationToken cancellationToken = default)
        {
            var category = await _context.StaffCategories.FindAsync(new object[] { categoryId }, cancellationToken);
            if (category == null) return false;

            category.CategoryName = newName;
            category.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(categoryId);
            return true;
        }

        public async Task<bool> UpdateCategoryDescriptionAsync(long categoryId, string newDescription, CancellationToken cancellationToken = default)
        {
            var category = await _context.StaffCategories.FindAsync(new object[] { categoryId }, cancellationToken);
            if (category == null) return false;

            category.Description = newDescription;
            category.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(categoryId);
            return true;
        }

        public async Task<bool> IsCategoryAssignedToStaffAsync(long categoryId, CancellationToken cancellationToken = default)
        {
            return await _context.Staffs.AsNoTracking()
                .AnyAsync(s => s.StaffCategoryId == categoryId, cancellationToken);
        }
        #endregion

        #region Workload & Assignments
        public async Task<IEnumerable<Staffs>> GetStaffByCategoryIdAsync(long categoryId, CancellationToken cancellationToken = default)
        {
            return await _context.Staffs.AsNoTracking()
                .Where(s => s.StaffCategoryId == categoryId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TaskToStaff>> GetTasksByCategoryIdAsync(long categoryId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TaskToStaff>().AsNoTracking()
                .Where(t => t.Staff.StaffCategoryId == categoryId)
                .Include(t => t.Task)
                .ToListAsync(cancellationToken);
        }
        #endregion

        #region Caching Helpers
        private async Task<bool> InvalidateCache(long categoryId)
        {
            var cacheKey = $"StaffCategory_GetById_{categoryId}";
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
