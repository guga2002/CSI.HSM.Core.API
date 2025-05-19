using Domain.Core.Entities.Item;
using Domain.Core.Entities.Task;
using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Task;

public interface ITaskRepository : IGenericRepository<Tasks>
{
    Task<IEnumerable<Tasks>> GetTasksByCartId(long cartId);
    Task<Dictionary<long, IEnumerable<TaskItem>>> GetTaskItemsByCartIdAsync(long cartId);
    Task<bool> UpdateTaskPriority(long taskId, long priorityId);
    Task<IEnumerable<Tasks>> GetFilteredTasks(long? priorityId, bool? isCompleted, DateTime? startDate, DateTime? endDate);
}