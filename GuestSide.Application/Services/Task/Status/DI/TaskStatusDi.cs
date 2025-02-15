using Microsoft.Extensions.DependencyInjection;
using Core.Application.Services.Task.Status.Services;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Task.Status.Mapper;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Core.Entities.Task;
using Core.Core.Interfaces.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.Task.Status;
using Core.Application.DTOs.Request.Task;
using Core.Infrastructure.Repositories.Task;

namespace Core.Application.Services.Task.Status.DI;

public static class TaskStatusDi
{
    public static void InjectTaskStatus(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<TasksStatus>, TaskStatusRepository>();
        services.AddScoped<ITaskStatusRepository, TaskStatusRepository>();
        services.AddScoped<ITaskStatusService, TaskStatusService>();
        services.AddScoped<IService<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus>, TaskStatusService>();
        services.AddScoped<IAdditionalFeatures<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus>, TaskStatusService>();
        services.AddAutoMapper(typeof(TaskStatusMapper));
        services.AddScoped<IAdditionalFeaturesRepository<TasksStatus>, AdditionalFeaturesRepository<TasksStatus>>();
    }
}
