using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Entities.Task;

namespace GuestSide.Application.Interface.Task.Task
{
    public interface ITaskService : IService<TaskDto,TaskResponseDto, long, Tasks>
    {
        Task<TaskCategoryResponseDto> GetTaskCategoryByTaskId(long TaskID, CancellationToken cancellationToken = default);

        Task<CartResponseDto> GetCardByTaskId(long TaskID, CancellationToken cancellationToken = default);
    }
}
