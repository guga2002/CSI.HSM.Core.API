using Microsoft.Extensions.DependencyInjection;
using Core.Application.Services.Hotel.Mapper;
using Core.Application.Interface.GenericContracts;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Core.Interfaces.Hotel;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.Interface.Hotel;
using Core.Infrastructure.Repositories.Hotel;

namespace Core.Application.Services.Hotel;

public static class HotelDi
{
    public static void InjectHotel(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Core.Entities.Hotel.Hotel>, HotelRepository>();
        services.AddAutoMapper(typeof(HotelMapper));
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IService<HotelRequestDto, HotelResponse, long, Core.Entities.Hotel.Hotel>, HotelService>();
        services.AddScoped<IAdditionalFeatures<HotelRequestDto, HotelResponse, long, Core.Entities.Hotel.Hotel>, HotelService>();
        services.AddScoped<IAdditionalFeaturesRepository<Core.Entities.Hotel.Hotel>, AdditionalFeaturesRepository<Core.Entities.Hotel.Hotel>>();
    }
}
