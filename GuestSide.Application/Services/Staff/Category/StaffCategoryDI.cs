using GuestSide.Application.DTOs.Staff;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Staff;
using GuestSide.Infrastructure.Repositories.Staff;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Application.Interface.Staff.Category;

namespace GuestSide.Application.Services.Staff.Category
{
    public static class StaffCategoryDI
    {
        public static void InjectStaffCategory(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<StaffCategory>, StaffCategoryRepository>();
            services.AddScoped<IStaffCategoryRepository, StaffCategoryRepository>();
            services.AddScoped<IStaffCategoryService, StaffCategoryService>();
            services.AddScoped<IService<StaffCategoryDto, long, StaffCategory>, StaffCategoryService>();

        }
    }
}
