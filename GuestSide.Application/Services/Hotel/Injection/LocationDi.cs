using Microsoft.Extensions.DependencyInjection;
using Core.Application.Services.Hotel.Service;
using Core.Application.Services.Hotel.Mapper;
using Core.Application.Interface.GenericContracts;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.Interface.Hotel;
using Common.Data.Entities.Hotel.GeoLocation;
using Common.Data.Interfaces.Hotel;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Hotel;

namespace Core.Application.Services.Hotel.Injection;

public static class LocationDi
{
    public static void InjectLocation(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Location>, LocationRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddAutoMapper(typeof(LocationMapper));
        services.AddScoped<IService<LocationRequestDto, LocationResponse, long, Location>, LocationService>();
        services.AddScoped<IAdditionalFeatures<LocationRequestDto, LocationResponse, long, Location>, LocationService>();
        services.AddScoped<IAdditionalFeaturesRepository<Location>, AdditionalFeaturesRepository<Location>>();
    }
}
