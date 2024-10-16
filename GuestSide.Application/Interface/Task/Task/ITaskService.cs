using GuestSide.Application.DTOs.Staff;
using GuestSide.Application.DTOs.Task;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Entities.Task;

namespace GuestSide.Application.Interface.Task.Task
{
    public interface ITaskService : IService<TaskDto, long, Tasks>
    {
        Task<TaskDto> GetTaskbycartId(long CartId, CancellationToken cancellationToken = default);
    }
}
