using Microsoft.Extensions.DependencyInjection;
using Core.Application.Services.Task.Task.Services;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Task.Task.Mapper;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.Task.Task;
using Core.Application.DTOs.Request.Task;
using Core.Infrastructure.Repositories.Task;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Task;
using Domain.Core.Entities.Task;

namespace Core.Application.Services.Task.Task.DI;

public static class TaskfDi
{
    public static void InjectTasks(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Tasks>, TaskRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<ITaskService, TasksService>();
        services.AddScoped<IService<TaskDto, TaskResponseDto, long, Tasks>, TasksService>();
        services.AddScoped<IAdditionalFeatures<TaskDto, TaskResponseDto, long, Tasks>, TasksService>();
        services.AddScoped<IAdditionalFeaturesRepository<Tasks>, AdditionalFeaturesRepository<Tasks>>();
        services.AddAutoMapper(typeof(TaskMapper));

    }
}
