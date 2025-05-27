using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Staff;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Staff;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Staff.StaffSupport;
using Core.Application.Services.Staff.StaffSupport.Mapper;
using Core.Application.Services.Staff.StaffSupport.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Staff.StaffSupport.DI
{
    public static class StaffSupportInject
    {
        public static void ActiveStaffSupport(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Common.Data.Entities.Staff.StaffSupport>, StaffSupportRepository>();
            services.AddScoped<IAdditionalFeaturesRepository<Common.Data.Entities.Staff.StaffSupport>, AdditionalFeaturesRepository<Common.Data.Entities.Staff.StaffSupport>>();
            services.AddScoped<IStaffSupportRepository, StaffSupportRepository>();
            services.AddScoped<IStaffSupportService, StaffSupportService>();
            services.AddScoped<IService<StaffSupportDto, StaffSupportResponseDto, long, Common.Data.Entities.Staff.StaffSupport>, StaffSupportService>();
            services.AddScoped<IAdditionalFeatures<StaffSupportDto, StaffSupportResponseDto, long, Common.Data.Entities.Staff.StaffSupport>, StaffSupportService>();
            services.AddAutoMapper(typeof(StaffSupportMapper));

        }
    }
}
