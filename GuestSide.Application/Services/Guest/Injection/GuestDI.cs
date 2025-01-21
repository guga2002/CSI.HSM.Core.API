using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Guest.Mapper;
using Core.Application.Services.Guest.Service;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;
using GuestSide.Application.DTOs.Request.Guest;
using GuestSide.Application.DTOs.Response.Guest;
using GuestSide.Application.Interface.Guest;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Guest;
using GuestSide.Infrastructure.Repositories.Guest;
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
