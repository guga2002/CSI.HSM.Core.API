using Core.Core.Entities.Staff;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Sheared;

namespace Core.Core.Interfaces.Staff
{
    public interface ITaskToStaffRepository : IGenericRepository<TaskToStaff>
    {
        Task<TaskToStaff> GetByTaskIdAsync(long taskId, CancellationToken cancellationToken = default);
        Task<IEnumerable<GroupTasksStatusByCard>> GetTasksStatusByCardAsync(long cardId, CancellationToken cancellationToken = default);
        Task<IEnumerable<TaskToStaff>> GetTasksByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);

        Task<bool> UpdateTaskStatusAsync(long taskId, long statusId, CancellationToken cancellationToken = default);
        Task<bool> MarkTaskAsCompletedAsync(long taskId, CancellationToken cancellationToken = default);
        Task<bool> AssignTaskToStaffAsync(long taskId, long staffId, CancellationToken cancellationToken = default);

        Task<IEnumerable<TaskToStaff>> GetActiveTasksByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);
        Task<IEnumerable<TaskToStaff>> GetDueTasksAsync(DateTime dueDate, CancellationToken cancellationToken = default);
    }
}