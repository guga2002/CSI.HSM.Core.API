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

namespace GuestSide.Application.Services.Staff.Cart
{
    public static class CartToStafDi
    {
        public static void InjectCartToStaff(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<CartToStaff>, CartToStaffRepository>();
            services.AddScoped<ICartToStaffRepository, CartToStaffRepository>();
            services.AddScoped<ICartToStaffService, TaskStatusService>();
            services.AddScoped<IService<CartToStaffDto,CartToStaffResponseDto, long, CartToStaff>, TaskStatusService>();
          
        }
    }
}
