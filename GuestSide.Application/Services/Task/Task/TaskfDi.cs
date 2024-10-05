using GuestSide.Application.Interface;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Core.Entities.Task;
using GuestSide.Infrastructure.Repositories.Task;
using GuestSide.Core.Interfaces.Task;
using GuestSide.Application.Interface.Task.Task;
using GuestSide.Application.DTOs.Task;

namespace GuestSide.Application.Services.Task.Status
{
    public static class TaskfDi
    {
        public static void InjectTasks(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Tasks>, TaskRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskService, TasksService>();
            services.AddScoped<IService<TaskDto, long, Tasks>, TasksService>();

        }
    }
}
