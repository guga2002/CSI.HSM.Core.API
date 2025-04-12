using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Staff.StaffSupportResponse;
using Core.Application.Services.Staff.StaffSupportResponse.Mapper;
using Core.Application.Services.Staff.StaffSupportResponse.Service;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Staff;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Staff;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Staff.StaffSupportResponse.DI;

public static class StaffSupportResponseInject
{
    public static void ActiveStaffSupportResponse(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Domain.Core.Entities.Staff.StaffSupportResponse>, StaffSupportResponseRepository>();
        services.AddScoped<IAdditionalFeaturesRepository<Domain.Core.Entities.Staff.StaffSupportResponse>, AdditionalFeaturesRepository<Domain.Core.Entities.Staff.StaffSupportResponse>>();
        services.AddScoped<IStaffSupportResponseRepository, StaffSupportResponseRepository>();
        services.AddScoped<IStaffSupportResponseService, StaffSupportResponseService>();
        services.AddScoped<IService<StaffSupportResponseRequestDto, StaffSupportResponseResponseDto, long, Domain.Core.Entities.Staff.StaffSupportResponse>, StaffSupportResponseService>();
        services.AddScoped<IAdditionalFeatures<StaffSupportResponseRequestDto, StaffSupportResponseResponseDto, long, Domain.Core.Entities.Staff.StaffSupportResponse>, StaffSupportResponseService>();
        services.AddAutoMapper(typeof(StaffSupportResponseMapper));
    }
}
