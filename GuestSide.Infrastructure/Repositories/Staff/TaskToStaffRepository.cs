using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Staff;
using Domain.Core.Interfaces.Staff;
using Domain.Core.Sheared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Staff
{
    public class TaskToStaffRepository : GenericRepository<TaskToStaff>, ITaskToStaffRepository
    {
        private readonly CoreSideDb _context;
        private readonly IRedisCash _redisCache;
        private readonly ILogger<TaskToStaff> _logger;

        public TaskToStaffRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<TaskToStaff> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
            _context = context;
            _redisCache = redisCache;
            _logger = logger;
        }

        #region Task Lookup & Filtering
        public async Task<TaskToStaff> GetByTaskIdAsync(long taskId, CancellationToken cancellationToken = default)
        {
            var taskToStaff = await DbSet.FirstOrDefaultAsync(task => task.TaskId == taskId, cancellationToken);
            if (taskToStaff != null) return taskToStaff;
            throw new ArgumentException("No task found with the given taskId.");
        }

        public async Task<IEnumerable<GroupTasksStatusByCard>> GetTasksStatusByCardAsync(long cardId, CancellationToken cancellationToken = default)
        {
            var result = DbSet
                .Include(t => t.Task)
                .Include(t => t.Status)
                .Where(t => t.Task.CartId == cardId)
                .GroupBy(t => t.Status.Name)
                .Select(group => new GroupTasksStatusByCard
                {
                    Status = group.Key,
                    Tasks = group.Select(t => t.Task).ToList()
                });

            return await result.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TaskToStaff>> GetTasksByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(t => t.AssignedByStaff.Id == staffId)
                .Include(t => t.AssignedByStaff)
                .Include(t => t.Task)
                .Include(t => t.Status)
                .ToListAsync(cancellationToken);
        }
        #endregion

        #region  Task Management
        public async Task<bool> UpdateTaskStatusAsync(long taskId, long statusId, CancellationToken cancellationToken = default)
        {
            var taskToStaff = await DbSet.FirstOrDefaultAsync(t => t.TaskId == taskId, cancellationToken);
            if (taskToStaff == null) return false;

            taskToStaff.StatusId = statusId;
            taskToStaff.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(taskId);
            return true;
        }

        public async Task<bool> MarkTaskAsCompletedAsync(long taskId, CancellationToken cancellationToken = default)
        {
            var taskToStaff = await DbSet.FirstOrDefaultAsync(t => t.TaskId == taskId, cancellationToken);
            if (taskToStaff == null) return false;

            taskToStaff.IsCompleted = true;
            taskToStaff.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(taskId);
            return true;
        }

        public async Task<bool> AssignTaskToStaffAsync(long taskId, long staffId, CancellationToken cancellationToken = default)
        {
            var taskToStaff = await DbSet.FirstOrDefaultAsync(t => t.TaskId == taskId, cancellationToken);
            if (taskToStaff == null) return false;

            taskToStaff.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(taskId);
            return true;
        }
        #endregion

        #region  Workload & Assignments
        public async Task<IEnumerable<TaskToStaff>> GetActiveTasksByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(t => t.AssignedByStaff.Id == staffId && !t.IsCompleted).
                Include(t => t.AssignedByStaff)
                .Include(t => t.Task)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TaskToStaff>> GetDueTasksAsync(DateTime dueDate, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(t => t.Task.DueDate <= dueDate && !t.IsCompleted)
                .Include(t => t.Task)
                .ToListAsync(cancellationToken);
        }
        #endregion

        #region  Caching Helpers
        private async Task<bool> InvalidateCache(long taskId)
        {
            var cacheKey = $"TaskToStaff_GetByTaskId_{taskId}";
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
