using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Staff;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Staff;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Staff.StaffSupportResponse;
using Core.Application.Services.Staff.StaffSupportResponse.Mapper;
using Core.Application.Services.Staff.StaffSupportResponse.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Staff.StaffSupportResponse.DI;

public static class StaffSupportResponseInject
{
    public static void ActiveStaffSupportResponse(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Common.Data.Entities.Staff.StaffSupportResponse>, StaffSupportResponseRepository>();
        services.AddScoped<IAdditionalFeaturesRepository<Common.Data.Entities.Staff.StaffSupportResponse>, AdditionalFeaturesRepository<Common.Data.Entities.Staff.StaffSupportResponse>>();
        services.AddScoped<IStaffSupportResponseRepository, StaffSupportResponseRepository>();
        services.AddScoped<IStaffSupportResponseService, StaffSupportResponseService>();
        services.AddScoped<IService<StaffSupportResponseRequestDto, StaffSupportResponseResponseDto, long, Common.Data.Entities.Staff.StaffSupportResponse>, StaffSupportResponseService>();
        services.AddScoped<IAdditionalFeatures<StaffSupportResponseRequestDto, StaffSupportResponseResponseDto, long, Common.Data.Entities.Staff.StaffSupportResponse>, StaffSupportResponseService>();
        services.AddAutoMapper(typeof(StaffSupportResponseMapper));
    }
}
