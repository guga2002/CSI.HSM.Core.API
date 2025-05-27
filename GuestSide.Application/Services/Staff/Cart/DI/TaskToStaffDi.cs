using Microsoft.Extensions.DependencyInjection;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.Task;
using Core.Application.Interface.GenericContracts;
using Core.Application.DTOs.Request.Staff;
using Core.Application.Services.Staff.Cart.Services;
using Common.Data.Entities.Staff;
using Common.Data.Interfaces.Staff;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Repositories.Staff;
using Common.Data.Repositories.AbstractRepository;

namespace Core.Application.Services.Staff.Cart.DI
{
    public static class TaskToStaffDi
    {
        public static void InjectCartToStaff(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<TaskToStaff>, TaskToStaffRepository>();
            services.AddScoped<IAdditionalFeaturesRepository<TaskToStaff>, AdditionalFeaturesRepository<TaskToStaff>>();
            services.AddScoped<ITaskToStaffRepository, TaskToStaffRepository>();
            services.AddScoped<ITaskToStaffService, TaskToStaffService>();
            services.AddScoped<IService<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>, TaskToStaffService>();
            services.AddScoped<IAdditionalFeatures<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>, TaskToStaffService>();
        }
    }
}
