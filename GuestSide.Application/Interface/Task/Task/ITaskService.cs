using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Task;

namespace Core.Application.Interface.Task.Task
{
    public interface ITaskService : IService<TaskDto, TaskResponseDto, long, Tasks>,
        IAdditionalFeatures<TaskDto, TaskResponseDto, long, Tasks>
    {
        /// <summary>
        /// Get all tasks assigned to a specific cart.
        /// </summary>
        /// <param name="cartId">Cart ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of TaskResponseDto</returns>
        Task<IEnumerable<TaskResponseDto>> GetTasksByCartId(long cartId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the status of a specific task.
        /// </summary>
        /// <param name="taskId">Task ID</param>
        /// <param name="newStatus">New Task Status</param>
        /// <returns>True if update is successful</returns>
        Task<bool> UpdateTaskStatus(long taskId, Core.Entities.Task.TaskStatus newStatus);

        /// <summary>
        /// Retrieves tasks filtered by status with an optional limit.
        /// </summary>
        /// <param name="status">Task Status</param>
        /// <param name="limit">Max number of tasks (default: 50)</param>
        /// <returns>List of TaskResponseDto</returns>
        Task<IEnumerable<TaskResponseDto>> GetTasksByStatus(Core.Entities.Task.TaskStatus status, int limit = 50);

        /// <summary>
        /// Retrieves high-priority tasks with a specified limit.
        /// </summary>
        /// <param name="limit">Max number of high-priority tasks (default: 10)</param>
        /// <returns>List of TaskResponseDto</returns>
        Task<IEnumerable<TaskResponseDto>> GetHighPriorityTasks(int limit = 10);
    }
}