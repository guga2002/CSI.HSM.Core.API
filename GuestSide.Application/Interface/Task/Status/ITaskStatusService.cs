using Common.Data.Entities.Task;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Task.Status
{
    public interface ITaskStatusService : IService<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus>,
        IAdditionalFeatures<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus>
    {
        /// <summary>
        /// Get all available task statuses.
        /// </summary>
        Task<IEnumerable<TaskStatusResponseDto>> GetAllTaskStatusesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a task status by its name.
        /// </summary>
        Task<TaskStatusResponseDto?> GetTaskStatusByNameAsync(string statusName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the name of a task status.
        /// </summary>
        Task<bool> UpdateTaskStatusNameAsync(long statusId, string newName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all active task statuses.
        /// </summary>
        Task<IEnumerable<TaskStatusResponseDto>> GetAllActiveStatusesAsync(CancellationToken cancellationToken = default);
    }
}