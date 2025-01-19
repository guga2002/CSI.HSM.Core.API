using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Core.Entities.Task;
using GuestSide.Infrastructure.Repositories.Task;
using GuestSide.Core.Interfaces.Task;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.Interface.Task.Category;
using GuestSide.Application.DTOs.Response.Task;
using Core.Application.Services.Task.Category.Services;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Task.Category.Mapper;

namespace Core.Application.Services.Task.Category.DI;

public static class TaskCategoryDI
{
    public static void InjectTaskCategory(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<TaskCategory>, TaskCategoryRepository>();
        services.AddScoped<ITaskCategoryRepository, TaskCategoryRepository>();
        services.AddScoped<ITaskCategoryService, TaskCategoryService>();
        services.AddScoped<IService<TaskCategoryDto, TaskCategoryResponseDto, long, TaskCategory>, TaskCategoryService>();
        services.AddScoped<IAdditionalFeatures<TaskCategoryDto, TaskCategoryResponseDto, long, TaskCategory>, TaskCategoryService>();
        services.AddAutoMapper(typeof(TaskCategoryMapper));
    }
}
