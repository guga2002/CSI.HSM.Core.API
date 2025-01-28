using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Item;

namespace Core.Application.Interface.Item;

public interface ITaskItemService : IService<TaskItemDto, TaskItemResponseDto, long, TaskItem>,
    IAdditionalFeatures<TaskItemDto, TaskItemResponseDto, long, TaskItem>
{

    Task<IEnumerable<TaskItemResponseDto>> GetTaskItemsByCartId(long CartId);
}
