using GuestSide.Application.Interface;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Application.Interface.Staff.Category;
using GuestSide.Core.Entities.Task;
using GuestSide.Infrastructure.Repositories.Task;
using GuestSide.Core.Interfaces.Task;
using GuestSide.Application.DTOs.Task;

namespace GuestSide.Application.Services.Task.Category
{
    public static class TaskCategoryDI
    {
        public static void InjectTaskCategory(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<TaskCategory>, TaskCategoryRepository>();
            services.AddScoped<ITaskCategoryRepository, TaskCategoryRepository>();
            services.AddScoped<ITaskCategoryService, TaskCategoryService>();
            services.AddScoped<IService<TaskCategoryDto, long, TaskCategory>, TaskCategoryService>();

        }
    }
}
