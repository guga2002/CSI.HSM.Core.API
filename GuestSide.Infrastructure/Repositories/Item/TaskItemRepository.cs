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
    public class TaskItemRepository : GenericRepository<TaskItem>, ITaskItemRepository
    {
        private readonly GuestSideDb _context;
        private readonly IRedisCash _redisCache;
        private readonly ILogger<TaskItem> _logger;

        public TaskItemRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<TaskItem> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
            _context = context;
            _redisCache = redisCache;
            _logger = logger;
        }

        #region Task-Item Lookup & Filtering
        public async Task<IEnumerable<TaskItem>> GetTaskItemsByTaskIdAsync(long taskId, CancellationToken cancellationToken = default)
        {
            return await _context.TaskItems.AsNoTracking()
                .Where(ti => ti.TaskId == taskId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TaskItem>> GetTaskItemsByItemIdAsync(long itemId, CancellationToken cancellationToken = default)
        {
            return await _context.TaskItems.AsNoTracking()
                .Where(ti => ti.ItemId == itemId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TaskItem>> GetPendingTaskItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.TaskItems.AsNoTracking()
                .Where(ti => !ti.IsCompleted)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TaskItem>> GetCompletedTaskItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.TaskItems.AsNoTracking()
                .Where(ti => ti.IsCompleted)
                .ToListAsync(cancellationToken);
        }
        #endregion

        #region Task-Item Management
        public async Task<bool> UpdateItemQuantityAsync(long taskItemId, int newQuantity, CancellationToken cancellationToken = default)
        {
            var taskItem = await _context.TaskItems.FindAsync(new object[] { taskItemId }, cancellationToken);
            if (taskItem == null) return false;

            taskItem.Quantity = newQuantity;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(taskItemId);
            return true;
        }

        public async Task<bool> MarkTaskItemCompletedAsync(long taskItemId, CancellationToken cancellationToken = default)
        {
            var taskItem = await _context.TaskItems.FindAsync(new object[] { taskItemId }, cancellationToken);
            if (taskItem == null) return false;

            taskItem.IsCompleted = true;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(taskItemId);
            return true;
        }

        public async Task<bool> AddNotesToTaskItemAsync(long taskItemId, string notes, CancellationToken cancellationToken = default)
        {
            var taskItem = await _context.TaskItems.FindAsync(new object[] { taskItemId }, cancellationToken);
            if (taskItem == null) return false;

            taskItem.Notes = notes;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(taskItemId);
            return true;
        }
        #endregion

        #region Task-Item Analytics
        public async Task<int> CountTotalItemsInTaskAsync(long taskId, CancellationToken cancellationToken = default)
        {
            return await _context.TaskItems
                .Where(ti => ti.TaskId == taskId)
                .CountAsync(cancellationToken);
        }

        public async Task<int> CountCompletedItemsInTaskAsync(long taskId, CancellationToken cancellationToken = default)
        {
            return await _context.TaskItems
                .Where(ti => ti.TaskId == taskId && ti.IsCompleted)
                .CountAsync(cancellationToken);
        }
        #endregion

   

        #region Caching Helpers
        private async Task<bool> InvalidateCache(long taskItemId)
        {
            var cacheKey = $"TaskItem_GetById_{taskItemId}";
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
