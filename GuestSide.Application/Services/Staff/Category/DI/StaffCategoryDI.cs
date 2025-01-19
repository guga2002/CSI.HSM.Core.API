using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Staff;
using GuestSide.Infrastructure.Repositories.Staff;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Application.Interface.Staff.Category;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using Core.Application.Services.Staff.Category.Services;

namespace Core.Application.Services.Staff.Category.DI
{
    public static class StaffCategoryDI
    {
        public static void InjectStaffCategory(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<StaffCategory>, StaffCategoryRepository>();
            services.AddScoped<IStaffCategoryRepository, StaffCategoryRepository>();
            services.AddScoped<IStaffCategoryService, StaffCategoryService>();
            services.AddScoped<IService<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory>, StaffCategoryService>();

        }
    }
}
