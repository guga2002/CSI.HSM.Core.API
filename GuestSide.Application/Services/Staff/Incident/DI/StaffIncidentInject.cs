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

public static class StaffIncidentInject
{
    public static void ActiveStaffIncident(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<StaffIncident>, StaffIncidentRepository>();
        services.AddScoped<IStaffIncidentRepository, StaffIncidentRepository>();
        services.AddScoped<IStaffIncidentService, StaffIncidentService>();
        services.AddScoped<IService<StaffIncidentDto, StaffIncidentResponseDto, long, StaffIncident>, StaffIncidentService>();
        services.AddScoped<IAdditionalFeatures<StaffIncidentDto, StaffIncidentResponseDto, long, StaffIncident>, StaffIncidentService>();
        services.AddAutoMapper(typeof(StaffIncidentMapper));
        services.AddScoped<IAdditionalFeaturesRepository<StaffIncident>, AdditionalFeaturesRepository<StaffIncident>>();
    }
}
