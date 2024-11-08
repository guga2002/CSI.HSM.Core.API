using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Application.Interface.Hotel;
using GuestSide.Application.Interface;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Hotel;
using GuestSide.Infrastructure.Repositories.Hotel;
using Microsoft.Extensions.DependencyInjection;

namespace GuestSide.Application.Services.Hotel
{
    public static class LocationDi
    {
        public static void InjectLocation(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<GuestSide.Core.Entities.Hotel.GeoLocation.Location>, ILocationRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IService<LocationrequestDto, LocationResponse, long, GuestSide.Core.Entities.Hotel.GeoLocation.Location>, LocationService>();
        }
    }
}
