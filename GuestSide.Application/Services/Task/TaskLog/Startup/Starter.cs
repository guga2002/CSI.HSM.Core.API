using Common.Data.Entities.Task;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Task;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Task;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Task.TaskLogs;
using Core.Application.Services.Task.TaskLog.Mapper;
using Core.Application.Services.Task.TaskLog.Service;
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
