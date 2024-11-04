using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;

namespace GuestSide.Application.Interface.Task.Status
{
    public interface ITaskStatusService : IService<TaskStatusDto,TaskStatusResponseDto, long, GuestSide.Core.Entities.Task.TasksStatus>
    {
    }
}
