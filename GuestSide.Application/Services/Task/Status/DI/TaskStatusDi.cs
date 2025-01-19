using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Core.Entities.Task;
using GuestSide.Infrastructure.Repositories.Task;
using GuestSide.Core.Interfaces.Task;
using GuestSide.Application.Interface.Task.Status;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using Core.Application.Services.Task.Status.Services;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Services.Task.Status.DI
{
    public static class TaskStatusDi
    {
        public static void InjectTaskStatus(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<TasksStatus>, TaskStatusRepository>();
            services.AddScoped<ITaskStatusRepository, TaskStatusRepository>();
            services.AddScoped<ITaskStatusService, TaskStatusService>();
            services.AddScoped<IService<TaskStatusDto, TaskStatusResponseDto, long, Core.Entities.Task.TasksStatus>, TaskStatusService>();

        }
    }
}
