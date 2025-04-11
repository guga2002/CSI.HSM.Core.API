using Microsoft.Extensions.DependencyInjection;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Entities.Staff;
using Domain.Core.Interfaces.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.Task;
using Core.Application.Interface.GenericContracts;
using Core.Application.DTOs.Request.Staff;
using Core.Application.Services.Staff.Cart.Services;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Staff;

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
