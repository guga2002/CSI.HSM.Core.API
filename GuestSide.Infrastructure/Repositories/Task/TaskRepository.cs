using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Item;
using Domain.Core.Entities.Task;
using Domain.Core.Interfaces.Task;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Task;

public class TaskRepository : GenericRepository<Tasks>, ITaskRepository
{
    public TaskRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Tasks> logger)
        : base(context, redisCache, httpContextAccessor, logger)
    {
    }

    #region Get Tasks by Cart ID
    public async Task<IEnumerable<Tasks>> GetTasksByCartId(long cartId)
    {
        return await DbSet
            .Where(task => task.CartId == cartId)
            .Include(t => t.TaskItems)
            .Include(t => t.TaskToStaff)
            .Include(t => t.Feedbacks)
            .ToListAsync();
    }
    #endregion

    #region GetTaskItemsByCartIdAsync

    public async Task<Dictionary<long, IEnumerable<TaskItem>>> GetTaskItemsByCartIdAsync(long cartId)
    {
        var res = await DbSet
            .Where(io => io.CartId == cartId)
            .Include(io => io.TaskItems)
            .Select(io => new KeyValuePair<long, IEnumerable<TaskItem>>(io.Id, io.TaskItems))
            .ToListAsync();

        return res.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
    #endregion

    #region Update Task Priority
    public async Task<bool> UpdateTaskPriority(long taskId, long priorityId)
    {
        var task = await DbSet.FindAsync(taskId);
        if (task == null) return false;

        task.PriorityId = priorityId;
        task.UpdatedAt = DateTime.UtcNow;
        await Context.SaveChangesAsync();

        return true;
    }
    #endregion

    #region FilterTask
    public async Task<IEnumerable<Tasks>> GetFilteredTasks(
           long? priorityId, bool? isCompleted, DateTime? startDate, DateTime? endDate)
    {
        return await DbSet
        .Where(t =>
            (!priorityId.HasValue || t.PriorityId == priorityId) &&
            (!isCompleted.HasValue || t.IsCompleted == isCompleted.Value) &&
            (!startDate.HasValue || t.CreatedAt >= startDate.Value) &&
            (!endDate.HasValue || t.CreatedAt <= endDate.Value))
        .Include(t => t.TaskItems)
        .ToListAsync();
    }
    #endregion
}
