using Core.Application.DTOs.Response.Item;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Task;

namespace Core.Application.Interface.Task;

public interface ITaskRelatedServices : IService<TaskDto, TaskResponseDto, long, Tasks>,
    IService<TaskCategoryDto, TaskCategoryResponseDto, long, TaskCategory>, 
    IService<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus>
{
    Task<TaskCategoryResponseDto>GetTaskCategoryByTaskId(long TaskId, CancellationToken cancellationToken = default);

    Task<OrderableItemResponseDto> GetOrderableItemByTaskId(long TaskId, CancellationToken cancellationToken = default);

    Task<CartResponseDto> GetCartByTaskId(long TaskId, CancellationToken cancellationToken = default);
}
