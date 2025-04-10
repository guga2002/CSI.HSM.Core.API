using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Task.Task;
using Core.Application.Interface.Task.TaskLogs;
using Core.Application.Services.Task.Task.Mapper;
using Core.Application.Services.Task.Task.Services;
using Core.Application.Services.Task.TaskLog.Mapper;
using Core.Application.Services.Task.TaskLog.Service;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Task;
using Domain.Core.Entities.Task;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Task;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Task.TaskLog.Startup;

public static class Starter
{
    public static void ActiveTaskLogs(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<TaskLogs>, TaskLogsRepository>();
        services.AddScoped<ITaskLogsRepository, TaskLogsRepository>();
        services.AddScoped<ITaskLogsService, TaskLogsService>();
        services.AddScoped<IService<TaskLogDto, TaskLogResponse, long, TaskLogs>, TaskLogsService>();
        services.AddScoped<IAdditionalFeatures<TaskLogDto, TaskLogResponse, long, TaskLogs>, TaskLogsService>();
        services.AddScoped<IAdditionalFeaturesRepository<TaskLogs>, AdditionalFeaturesRepository<TaskLogs>>();
        services.AddAutoMapper(typeof(TaskLogMapper));

    }
}
