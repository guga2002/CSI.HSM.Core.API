using GuestSide.Application.DTOs.Staff;
using GuestSide.Application.DTOs.Task;
using GuestSide.Core.Entities.Staff;

namespace GuestSide.Application.Interface.Task.Status
{
    public interface ITaskStatusService : IService<TaskStatusDto, long, GuestSide.Core.Entities.Task.TasksStatus>
    {
    }
}
