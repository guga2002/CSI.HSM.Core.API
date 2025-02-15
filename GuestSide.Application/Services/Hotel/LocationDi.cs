using Microsoft.Extensions.DependencyInjection;
using Core.Application.Services.Hotel.Mapper;
using Core.Application.Interface.GenericContracts;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Core.Interfaces.Hotel;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.Interface.Hotel;
using Core.Core.Entities.Hotel.GeoLocation;
using Core.Infrastructure.Repositories.Hotel;

namespace Core.Application.Services.Hotel;

public static class LocationDi
{
    public static void InjectLocation(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Location>, LocationRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddAutoMapper(typeof(LocationMapper));
        services.AddScoped<IService<LocationrequestDto, LocationResponse, long, Location>, LocationService>();
        services.AddScoped<IAdditionalFeatures<LocationrequestDto, LocationResponse, long, Location>, LocationService>();
        services.AddScoped<IAdditionalFeaturesRepository<Location>, AdditionalFeaturesRepository<Location>>();
    }
}
