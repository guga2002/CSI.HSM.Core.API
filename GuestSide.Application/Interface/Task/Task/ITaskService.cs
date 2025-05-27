using Common.Data.Entities.Enums;
using Common.Data.Entities.Item;
using Common.Data.Entities.Task;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Task.Task;

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
    Task<bool> UpdateTaskStatus(long taskId, StatusEnum newStatus);

    /// <summary>
    /// Updates the priority of a specific task.
    /// </summary>
    /// <param name="taskId"></param>
    /// <param name="newPriority"></param>
    /// <returns></returns>
    Task<bool> UpdateTaskPriority(long taskId, PriorityEnum newPriority);

    /// <summary>
    /// Retrieves tasks filtered by status with an optional limit.
    /// </summary>
    /// <param name="status">Task Status</param>
    /// <param name="limit">Max number of tasks (default: 50)</param>
    /// <returns>List of TaskResponseDto</returns>
    Task<IEnumerable<TaskResponseDto>> GetTasksByStatus(StatusEnum status, int limit = 50);

    /// <summary>
    /// Retrieves high-priority tasks with a specified limit.
    /// </summary>
    /// <param name="limit">Max number of high-priority tasks (default: 10)</param>
    /// <returns>List of TaskResponseDto</returns>
    Task<IEnumerable<TaskResponseDto>> GetHighPriorityTasks(int limit = 10);

    /// <summary>
    /// Get Task Items By Cart Id Async
    /// </summary>
    /// <param name="cartId"></param>
    /// <returns></returns>
    Task<Dictionary<long, IEnumerable<TaskItem>>> GetTaskItemsByCartIdAsync(long cartId);

    /// <summary>
    /// Get task by filter parameters
    /// </summary>
    /// <param name="filterTaskDto"></param>
    /// <returns></returns>
    Task<IEnumerable<TaskResponseDto>> GetFilteredTasks(FilterTaskDto filterTaskDto);
}