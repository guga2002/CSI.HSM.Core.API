using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.Services;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Item.Services;

public class TaskItemService : GenericService<TaskItemDto, TaskItemResponseDto, long, TaskItem>, ITaskItemService
{
    public TaskItemService(IMapper mapper, 
        IGenericRepository<TaskItem> repository, 
        ILogger<GenericService<TaskItemDto, TaskItemResponseDto, long, TaskItem>> logger, 
        IAdditionalFeaturesRepository<TaskItem> additioalFeatures) 
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
