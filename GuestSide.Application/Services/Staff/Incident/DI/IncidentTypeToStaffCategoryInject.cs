using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Staff.Incident;
using Core.Application.Services.Staff.Incident.Mapper;
using Core.Application.Services.Staff.Incident.Service;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Staff;
using Domain.Core.Entities.Staff;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Staff;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Staff.Incident.DI;

public static class IncidentTypeToStaffCategoryInject
{
    public static void IncidentTypeToStaffCategoryDI(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<IncidentTypeToStaffCategory>, IncidentTypeToStaffCategoryRepository>();
        services.AddScoped<IIncidentTypeToStaffCategoryRepository, IncidentTypeToStaffCategoryRepository>();
        services.AddScoped<IIncidentTypeToStaffCategoryService, IncidentTypeToStaffCategoryService>();
        services.AddScoped<IService<IncidentTypeToStaffCategoryDto,
    IncidentTypeToStaffCategoryResponseDto, long, IncidentTypeToStaffCategory>, IncidentTypeToStaffCategoryService>();
        services.AddScoped<IAdditionalFeatures<IncidentTypeToStaffCategoryDto,
    IncidentTypeToStaffCategoryResponseDto, long, IncidentTypeToStaffCategory>, IncidentTypeToStaffCategoryService>();
        services.AddScoped<IAdditionalFeaturesRepository<IncidentTypeToStaffCategory>, AdditionalFeaturesRepository<IncidentTypeToStaffCategory>>();
        services.AddAutoMapper(typeof(IncidentTypeToStaffCategoryMapper));
    }
}