using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Staff;

namespace Core.Application.Interface.Staff.Task;

public interface ITaskToStaffService : IService<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>,
    IAdditionalFeatures<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>
{
    Task<TaskToStaffResponseDto> GetByTaskId(long taskId);
    Task<IEnumerable<GroupTasksStatusByCardDto>> GetTasksStatusByCard(long cardId);
}
