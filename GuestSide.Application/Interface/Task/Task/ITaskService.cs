using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;
using Domain.Core.Entities.Enums;
using Domain.Core.Entities.Item;
using Domain.Core.Entities.Task;

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
    /// Updates the priority of a specific task.
    /// </summary>
    /// <param name="taskId"></param>
    /// <param name="newPriority"></param>
    /// <returns></returns>
    Task<bool> UpdateTaskPriority(long taskId, long priorityId);

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