using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Staff.StaffSupport;
using Core.Application.Services.Staff.StaffSupport.Mapper;
using Core.Application.Services.Staff.StaffSupport.Service;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Staff;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Staff;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Staff.StaffSupport.DI
{
    public static class StaffSupportInject
    {
        public static void ActiveStaffSupport(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Domain.Core.Entities.Staff.StaffSupport>, StaffSupportRepository>();
            services.AddScoped<IAdditionalFeaturesRepository<Domain.Core.Entities.Staff.StaffSupport>, AdditionalFeaturesRepository<Domain.Core.Entities.Staff.StaffSupport>>();
            services.AddScoped<IStaffSupportRepository, StaffSupportRepository>();
            services.AddScoped<IStaffSupportService, StaffSupportService>();
            services.AddScoped<IService<StaffSupportDto, StaffSupportResponseDto, long, Domain.Core.Entities.Staff.StaffSupport>, StaffSupportService>();
            services.AddScoped<IAdditionalFeatures<StaffSupportDto, StaffSupportResponseDto, long, Domain.Core.Entities.Staff.StaffSupport>, StaffSupportService>();
            services.AddAutoMapper(typeof(StaffSupportMapper));

        }
    }
}
