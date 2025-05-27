using Microsoft.Extensions.DependencyInjection;
using Core.Application.Services.Hotel.Mapper;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Hotel.Service;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.Interface.Hotel;
using Common.Data.Interfaces.Hotel;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Repositories.Hotel;
using Common.Data.Repositories.AbstractRepository;

namespace Core.Application.Services.Hotel.Injection;

public static class HotelDi
{
    public static void InjectHotel(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Common.Data.Entities.Hotel.Hotel>, HotelRepository>();
        services.AddAutoMapper(typeof(HotelMapper));
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IService<HotelRequestDto, HotelResponse, long, Common.Data.Entities.Hotel.Hotel>, HotelService>();
        services.AddScoped<IAdditionalFeatures<HotelRequestDto, HotelResponse, long, Common.Data.Entities.Hotel.Hotel>, HotelService>();
        services.AddScoped<IAdditionalFeaturesRepository<Common.Data.Entities.Hotel.Hotel>, AdditionalFeaturesRepository<Common.Data.Entities.Hotel.Hotel>>();
    }
}
