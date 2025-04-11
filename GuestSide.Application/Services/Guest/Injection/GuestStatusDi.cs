using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Guest;
using Core.Application.Services.Guest.Mapper;
using Core.Application.Services.Guest.Service;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Guest;
using Domain.Core.Entities.Guest;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Guest;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Guest.Injection;

public static class GuestStatusDi
{

    public static void InjectGuestStatus(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Status>, StatusRepository>();
        services.AddScoped<IStatusRepository, StatusRepository>();
        services.AddScoped<IGuestStatusService, GuestStatusService>();
        services.AddScoped<IService<StatusDto, GuestStatusResponseDto, long, Status>, GuestStatusService>();
        services.AddScoped<IAdditionalFeatures<StatusDto, GuestStatusResponseDto, long, Status>, GuestStatusService>();
        services.AddScoped<IAdditionalFeaturesRepository<Status>, AdditionalFeaturesRepository<Status>>();
        services.AddAutoMapper(typeof(GuestStatusMapper));
    }
    
}
