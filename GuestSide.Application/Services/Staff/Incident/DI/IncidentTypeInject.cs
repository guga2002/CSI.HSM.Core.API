using Common.Data.Entities.Staff;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Staff;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Staff;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Staff.Incident;
using Core.Application.Services.Staff.Incident.Mapper;
using Core.Application.Services.Staff.Incident.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Staff.Incident.DI;

public static class IncidentTypeInject
{
    public static void IncidentTypeDI(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<IncidentType>, IncidentTypeRepository>();
        services.AddScoped<IIncidentTypeRepository, IncidentTypeRepository>();
        services.AddScoped<IIncidentTypeService, IncidentTypeService>();
        services.AddScoped<IService<IncidentTypeDto, IncidentTypeResponseDto, long, IncidentType>, IncidentTypeService>();
        services.AddScoped<IAdditionalFeatures<IncidentTypeDto, IncidentTypeResponseDto, long, IncidentType>, IncidentTypeService>();
        services.AddScoped<IAdditionalFeaturesRepository<IncidentType>, AdditionalFeaturesRepository<IncidentType>>();
        services.AddAutoMapper(typeof(IncidentTypeMapper));
    }
}
