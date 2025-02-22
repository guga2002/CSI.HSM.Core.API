using Core.Core.Entities.Item;
using Core.Core.Entities.Task;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Task
{
    public interface ITaskRepository : IGenericRepository<Tasks>
    {
        Task<IEnumerable<Tasks>> GetTasksByCartId(long cartId);
        Task<bool> UpdateTaskStatus(long taskId, Entities.Task.TaskStatus newStatus);
        Task<IEnumerable<Tasks>> GetTasksByStatus(Entities.Task.TaskStatus status, int limit = 50);
        Task<IEnumerable<Tasks>> GetHighPriorityTasks(int limit = 10);
        Task<Dictionary<long, IEnumerable<TaskItem>>> GetTaskItemsByCartIdAsync(long cartId);
    }
}