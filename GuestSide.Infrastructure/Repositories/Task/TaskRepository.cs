using Core.Core.Data;
using Core.Core.Entities.Item;
using Core.Core.Entities.Task;
using Core.Core.Interfaces.Task;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskStatus = Core.Core.Entities.Task.TaskStatus;

namespace Core.Infrastructure.Repositories.Task;

public class TaskRepository : GenericRepository<Tasks>, ITaskRepository
{
    public TaskRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Tasks> logger)
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

    #region Update Task Status
    public async Task<bool> UpdateTaskStatus(long taskId, TaskStatus newStatus)
    {
        var task = await DbSet.FindAsync(taskId);
        if (task == null) return false;

        task.Status = newStatus;
        task.UpdatedAt = DateTime.UtcNow;
        await Context.SaveChangesAsync();

        return true;
    }
    #endregion

    #region  Get Tasks by Status
    public async Task<IEnumerable<Tasks>> GetTasksByStatus(TaskStatus status, int limit = 50)
    {
        return await DbSet
            .Where(task => task.Status == status)
            .OrderByDescending(task => task.CreatedDate)
            .Take(limit)
            .Include(t => t.TaskToStaff)
            .Include(t => t.TaskItems)
            .ToListAsync();
    }
    #endregion

    #region Get High Priority Tasks
    public async Task<IEnumerable<Tasks>> GetHighPriorityTasks(int limit = 10)
    {
        return await DbSet
            .Where(task => task.Priority == TaskPriority.High || task.Priority == TaskPriority.Critical)
            .OrderByDescending(task => task.CreatedDate)
            .Take(limit)
            .Include(t => t.TaskToStaff)
            .Include(t => t.TaskItems)
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
    public async Task<bool> UpdateTaskPriority(long taskId, TaskPriority newPriority)
    {
        var task = await DbSet.FindAsync(taskId);
        if (task == null) return false;

        task.Priority = newPriority;
        task.UpdatedAt = DateTime.UtcNow;
        await Context.SaveChangesAsync();

        return true;
    }
    #endregion

    #region FilterTask
    public async Task<IEnumerable<Tasks>> GetFilteredTasks(
        TaskStatus? status, TaskPriority? priority, bool? isCompleted, DateTime? startDate, DateTime? endDate)
    {
        return await DbSet
        .Where(t =>
            (!status.HasValue || t.Status == status.Value) &&
            (!priority.HasValue || t.Priority == priority.Value) &&
            (!isCompleted.HasValue || t.IsCompleted == isCompleted.Value) &&
            (!startDate.HasValue || t.CreatedDate >= startDate.Value) &&
            (!endDate.HasValue || t.CreatedDate <= endDate.Value)) 
        .Include(t => t.TaskItems)
        .ToListAsync();
    }
    #endregion
}
