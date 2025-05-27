using Common.Data.Entities.Item;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Item;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Item;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Item;
using Core.Application.Services.Item.Mapper;
using Core.Application.Services.Item.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Item.DI;

public static class TaskItemDI
{
    public static void InjectTaskItem(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<TaskItem>, TaskItemRepository>();
        services.AddScoped<ITaskItemRepository, TaskItemRepository>();
        services.AddScoped<ITaskItemService, TaskItemService>();
        services.AddScoped<IService<TaskItemDto, TaskItemResponseDto, long, TaskItem>, TaskItemService>();
        services.AddScoped<IAdditionalFeatures<TaskItemDto, TaskItemResponseDto, long, TaskItem>, TaskItemService>();
        services.AddScoped<IAdditionalFeaturesRepository<TaskItem>, AdditionalFeaturesRepository<TaskItem>>();
        services.AddAutoMapper(typeof(TaskItemMapper));
    }
}
