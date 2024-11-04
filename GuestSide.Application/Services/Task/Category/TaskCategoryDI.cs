using GuestSide.Application.Interface;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Core.Entities.Task;
using GuestSide.Infrastructure.Repositories.Task;
using GuestSide.Core.Interfaces.Task;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.Interface.Task.Category;
using GuestSide.Application.DTOs.Response.Task;

namespace GuestSide.Application.Services.Task.Category
{
    public static class TaskCategoryDI
    {
        public static void InjectTaskCategory(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<TaskCategory>, TaskCategoryRepository>();
            services.AddScoped<ITaskCategoryRepository, TaskCategoryRepository>();
            services.AddScoped<ITaskCategoryService, TaskCategoryService>();
            services.AddScoped<IService<TaskCategoryDto,TaskCategoryResponseDto, long, TaskCategory>, TaskCategoryService>();

        }
    }
}
