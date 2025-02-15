using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Item
{
    public interface ITaskItemRepository : IGenericRepository<TaskItem>
    {
        Task<IEnumerable<TaskItem>> GetTaskItemsByTaskIdAsync(long taskId, CancellationToken cancellationToken = default);
        Task<IEnumerable<TaskItem>> GetTaskItemsByItemIdAsync(long itemId, CancellationToken cancellationToken = default);
        Task<IEnumerable<TaskItem>> GetPendingTaskItemsAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TaskItem>> GetCompletedTaskItemsAsync(CancellationToken cancellationToken = default);

        Task<bool> UpdateItemQuantityAsync(long taskItemId, int newQuantity, CancellationToken cancellationToken = default);
        Task<bool> MarkTaskItemCompletedAsync(long taskItemId, CancellationToken cancellationToken = default);
        Task<bool> AddNotesToTaskItemAsync(long taskItemId, string notes, CancellationToken cancellationToken = default);

        Task<int> CountTotalItemsInTaskAsync(long taskId, CancellationToken cancellationToken = default);
        Task<int> CountCompletedItemsInTaskAsync(long taskId, CancellationToken cancellationToken = default);
    }
}