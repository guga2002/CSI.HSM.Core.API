using GuestSide.Application.Interface;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Core.Entities.Staff;
using GuestSide.Infrastructure.Repositories.Staff;
using GuestSide.Core.Interfaces.Staff;
using GuestSide.Application.Interface.Staff.Cart;
using GuestSide.Application.Interface.Task.Task;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;

namespace Core.Application.Services.Staff.Cart.DI
{
    public static class TaskToStaffDi
    {
        public static void InjectCartToStaff(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<TaskToStaff>, TaskToStaffRepository>();
            services.AddScoped<ITaskToStaffRepository, TaskToStaffRepository>();
            services.AddScoped<ICartToStaffService, TaskStatusService>();
            services.AddScoped<IService<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>, TaskStatusService>();

        }
    }
}
