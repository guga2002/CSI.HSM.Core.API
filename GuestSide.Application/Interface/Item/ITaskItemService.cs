using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Item;

namespace Core.Application.Interface.Item;

public interface ITaskItemService : IService<TaskItemDto, TaskItemResponseDto, long, TaskItem>,
    IAdditionalFeatures<TaskItemDto, TaskItemResponseDto, long, TaskItem>
{
    /// <summary>
    /// Get task items by Task ID.
    /// </summary>
    Task<IEnumerable<TaskItemResponseDto>> GetTaskItemsByTaskIdAsync(long taskId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get task items by Item ID.
    /// </summary>
    Task<IEnumerable<TaskItemResponseDto>> GetTaskItemsByItemIdAsync(long itemId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all pending task items.
    /// </summary>
    Task<IEnumerable<TaskItemResponseDto>> GetPendingTaskItemsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all completed task items.
    /// </summary>
    Task<IEnumerable<TaskItemResponseDto>> GetCompletedTaskItemsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the quantity of a task item.
    /// </summary>
    Task<bool> UpdateItemQuantityAsync(long taskItemId, int newQuantity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Mark a task item as completed.
    /// </summary>
    Task<bool> MarkTaskItemCompletedAsync(long taskItemId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add notes to a task item.
    /// </summary>
    Task<bool> AddNotesToTaskItemAsync(long taskItemId, string notes, CancellationToken cancellationToken = default);

    /// <summary>
    /// Count total items in a task.
    /// </summary>
    Task<int> CountTotalItemsInTaskAsync(long taskId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Count completed items in a task.
    /// </summary>
    Task<int> CountCompletedItemsInTaskAsync(long taskId, CancellationToken cancellationToken = default);
}
