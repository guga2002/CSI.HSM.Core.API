using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Application.Interface.Hotel;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Hotel;
using GuestSide.Infrastructure.Repositories.Hotel;
using Microsoft.Extensions.DependencyInjection;
using Core.Application.Services.Hotel.Mapper;
using Core.Application.Interface.GenericContracts;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;

namespace GuestSide.Application.Services.Hotel;

public static class LocationDi
{
    public static void InjectLocation(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<GuestSide.Core.Entities.Hotel.GeoLocation.Location>, LocationRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddAutoMapper(typeof(LocationMapper));
        services.AddScoped<IService<LocationrequestDto, LocationResponse, long, GuestSide.Core.Entities.Hotel.GeoLocation.Location>, LocationService>();
        services.AddScoped<IAdditionalFeatures<LocationrequestDto, LocationResponse, long, GuestSide.Core.Entities.Hotel.GeoLocation.Location>, LocationService>();
        services.AddScoped<IAdditionalFeaturesRepository<GuestSide.Core.Entities.Hotel.GeoLocation.Location>, AdditionalFeaturesRepository<GuestSide.Core.Entities.Hotel.GeoLocation.Location>>();
    }
}
