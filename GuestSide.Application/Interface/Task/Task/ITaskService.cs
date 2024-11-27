using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Core.Entities.Task;

namespace GuestSide.Application.Interface.Task.Task
{
    public interface ITaskService : IService<TaskDto,TaskResponseDto, long, Tasks>
    {
        Task<TaskResponseDto> GetTaskbycartId(long CartId, CancellationToken cancellationToken = default);
    }
}
