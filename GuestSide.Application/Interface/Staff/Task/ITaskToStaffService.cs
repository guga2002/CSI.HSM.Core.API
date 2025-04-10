using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Domain.Core.Entities.Staff;
using Domain.Core.Sheared;

namespace Core.Application.Interface.Staff.Task
{
    public interface ITaskToStaffService : IService<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>,
        IAdditionalFeatures<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>
    {
        /// <summary>
        /// Get a task assigned to a staff member by task ID.
        /// </summary>
        Task<TaskToStaffResponseDto?> GetByTaskIdAsync(long taskId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get task status grouped by card.
        /// </summary>
        Task<IEnumerable<GroupTasksStatusByCard>> GetTasksStatusByCardAsync(long cardId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all tasks assigned to a specific staff member.
        /// </summary>
        Task<IEnumerable<TaskToStaffResponseDto>> GetTasksByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update task status for a staff-assigned task.
        /// </summary>
        Task<bool> UpdateTaskStatusAsync(long taskId, long statusId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Mark a task as completed.
        /// </summary>
        Task<bool> MarkTaskAsCompletedAsync(long taskId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assign a task to a staff member.
        /// </summary>
        Task<bool> AssignTaskToStaffAsync(long taskId, long staffId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get active tasks assigned to a staff member.
        /// </summary>
        Task<IEnumerable<TaskToStaffResponseDto>> GetActiveTasksByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get tasks that are due by a specific date.
        /// </summary>
        Task<IEnumerable<TaskToStaffResponseDto>> GetDueTasksAsync(DateTime dueDate, CancellationToken cancellationToken = default);
    }
}
