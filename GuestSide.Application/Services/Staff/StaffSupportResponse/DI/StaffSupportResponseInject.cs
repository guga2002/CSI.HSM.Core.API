using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Staff;
using Core.Application.Interface.Staff.staf;
using Core.Application.Services.Staff.Staff.Mapper;
using Core.Application.Services.Staff.Staff.Services;
using Core.Application.Services.Staff.StaffSupportResponse.Mapper;
using Core.Application.Services.Staff.StaffSupportResponse.Service;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Staff;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Staff;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Staff.StaffSupportResponse.DI
{
    public static class StaffSupportResponseInject
    {
        public static void ActiveStaffSupportResponse(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Core.Entities.Staff.StaffSupportResponse>, StaffSupportResponseRepository>();
            services.AddScoped<IAdditionalFeaturesRepository<Core.Entities.Staff.StaffSupportResponse>, AdditionalFeaturesRepository<Core.Entities.Staff.StaffSupportResponse>>();
            services.AddScoped<IStaffSupportResponseRepository, StaffSupportResponseRepository>();
            services.AddScoped<IStaffSupportResponseService, StaffSupportResponseService>();
            services.AddScoped<IService<StaffSupportResponseDto, StaffSupportResponseResponseDto, long, Core.Entities.Staff.StaffSupportResponse>, StaffSupportResponseService>();
            services.AddScoped<IAdditionalFeatures<StaffSupportResponseDto, StaffSupportResponseResponseDto, long, Core.Entities.Staff.StaffSupportResponse>, StaffSupportResponseService>();
            services.AddAutoMapper(typeof(StaffSupportResponseMapper));
        }
    }
}
