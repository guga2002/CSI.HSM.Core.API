using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Guest;
using Core.Application.Services.Guest.Mapper;
using Core.Application.Services.Guest.Service;
using Core.Core.Entities.Guest;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Guest;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Guest;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Guest.Injection;

public static class GuestDI
{
    public static void InjectGuest(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Guests>, GuestRepository>();
        services.AddScoped<IGuestRepository, GuestRepository>();
        services.AddScoped<IGuestService, GuestService>();
        services.AddScoped<IService<GuestDto, GuestResponseDto, long, Guests>, GuestService>();
        services.AddScoped<IAdditionalFeatures<GuestDto, GuestResponseDto, long, Guests>, GuestService>();
        services.AddScoped<IAdditionalFeaturesRepository<Guests>, AdditionalFeaturesRepository<Guests>>();
        services.AddAutoMapper(typeof(GuestMapper));
        //services.AddScoped<ILogger<GenericService<GuestDto, long, Guests>>>();
    }
}
