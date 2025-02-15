using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Item;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Item.Services;

public class TaskItemService : GenericService<TaskItemDto, TaskItemResponseDto, long, TaskItem>, ITaskItemService
{
    private readonly ITaskItem _itemTaskrepository;
    private readonly IMapper _map;
    public TaskItemService(IMapper mapper, 
        IGenericRepository<TaskItem> repository, 
        ILogger<GenericService<TaskItemDto, TaskItemResponseDto, long, TaskItem>> logger, 
        IAdditionalFeaturesRepository<TaskItem> additioalFeatures, ITaskItem itemTaskrepository) 
        : base(mapper, repository, logger, additioalFeatures)
    {
        _itemTaskrepository = itemTaskrepository;
        _map = mapper;
    }

    public async Task<IEnumerable<TaskItemResponseDto>> GetTaskItemsByCartId(long CartId)
    {
        var res = await _itemTaskrepository.GetTaskItemsByCartId(CartId);
        return _map.Map<IEnumerable<TaskItemResponseDto>>(res);
    }
}
