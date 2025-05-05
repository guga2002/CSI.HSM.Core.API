using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Enums;
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

    #region Update Task Status
    public async Task<bool> UpdateTaskStatus(long taskId, StatusEnum newStatus)
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
    public async Task<IEnumerable<Tasks>> GetTasksByStatus(StatusEnum status, int limit = 50)
    {
        return await DbSet
            .Where(task => task.Status == status)
            .OrderByDescending(task => task.CreatedAt)
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
            .Where(task => task.Priority == PriorityEnum.High || task.Priority == PriorityEnum.Critical)
            .OrderByDescending(task => task.CreatedAt)
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
    public async Task<bool> UpdateTaskPriority(long taskId, PriorityEnum newPriority)
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
        StatusEnum? status, PriorityEnum? priority, bool? isCompleted, DateTime? startDate, DateTime? endDate)
    {
        return await DbSet
        .Where(t =>
            (!status.HasValue || t.Status == status.Value) &&
            (!priority.HasValue || t.Priority == priority.Value) &&
            (!isCompleted.HasValue || t.IsCompleted == isCompleted.Value) &&
            (!startDate.HasValue || t.CreatedAt >= startDate.Value) &&
            (!endDate.HasValue || t.CreatedAt <= endDate.Value))
        .Include(t => t.TaskItems)
        .ToListAsync();
    }
    #endregion
}
