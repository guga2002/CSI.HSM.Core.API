using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Core.Interfaces.Hotel;
using GuestSide.Infrastructure.Repositories.Hotel;
using GuestSide.Application.Interface.Hotel;
using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;
using Core.Application.Services.Hotel.Mapper;
using Core.Application.Interface.GenericContracts;

namespace GuestSide.Application.Services.Hotel;

public static  class HotelDi
{
    public static void InjectHotel(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<GuestSide.Core.Entities.Hotel.Hotel>, HotelRepository>();
        services.AddAutoMapper(typeof(HotelMapper));
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IService<HotelRequestDto, HotelResponse, long, GuestSide.Core.Entities.Hotel.Hotel>, HotelService>();
        services.AddScoped<IAdditionalFeatures<HotelRequestDto, HotelResponse, long, GuestSide.Core.Entities.Hotel.Hotel>, HotelService>();
    }
}
