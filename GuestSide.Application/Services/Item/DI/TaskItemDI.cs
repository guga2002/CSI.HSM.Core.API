using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Item;
using Core.Application.Services.Item.Mapper;
using Core.Application.Services.Item.Services;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Item;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Item;
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
