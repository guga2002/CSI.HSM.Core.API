using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Staff.StaffSupport;
using Core.Application.Services.Staff.StaffSupport.Mapper;
using Core.Application.Services.Staff.StaffSupport.Service;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Staff;
using Domain.Application.Interface.Staff.staf;
using Domain.Application.Services.Staff.Staff.Mapper;
using Domain.Application.Services.Staff.Staff.Services;
using Domain.Core.Entities.Staff;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Staff;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Staff.StaffSupport.DI
{
    public static class StaffSupportInject
    {
        public static void ActiveStaffSupport(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Core.Entities.Staff.StaffSupport>, StaffSupportRepository>();
            services.AddScoped<IAdditionalFeaturesRepository<Core.Entities.Staff.StaffSupport>, AdditionalFeaturesRepository<Core.Entities.Staff.StaffSupport>>();
            services.AddScoped<IStaffSupportRepository, StaffSupportRepository>();
            services.AddScoped<IStaffSupportService, StaffSupportService>();
            services.AddScoped<IService<StaffSupportDto, StaffSupportResponseDto, long, Core.Entities.Staff.StaffSupport>, StaffSupportService>();
            services.AddScoped<IAdditionalFeatures<StaffSupportDto, StaffSupportResponseDto, long, Core.Entities.Staff.StaffSupport>, StaffSupportService>();
            services.AddAutoMapper(typeof(StaffSupportMapper));

        }
    }
}
