using Microsoft.Extensions.DependencyInjection;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Hotel;
using Core.Application.Services.Hotel.Mapper;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Hotel.Service;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.Interface.Hotel;
using Core.Infrastructure.Repositories.Hotel;
using Core.Infrastructure.Repositories.AbstractRepository;

namespace Core.Application.Services.Hotel.Injection;

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
