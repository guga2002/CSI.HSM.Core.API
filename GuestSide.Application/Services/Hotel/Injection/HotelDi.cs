using Microsoft.Extensions.DependencyInjection;
using Core.Application.Services.Hotel.Mapper;
using Core.Application.Interface.GenericContracts;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.Interface.Hotel;
using Core.Infrastructure.Repositories.Hotel;
using Core.Application.Services.Hotel.Service;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Hotel;

namespace Core.Application.Services.Hotel.Injection;

public static class HotelDi
{
    public static void InjectHotel(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Domain.Core.Entities.Hotel.Hotel>, HotelRepository>();
        services.AddAutoMapper(typeof(HotelMapper));
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IService<HotelRequestDto, HotelResponse, long, Domain.Core.Entities.Hotel.Hotel>, HotelService>();
        services.AddScoped<IAdditionalFeatures<HotelRequestDto, HotelResponse, long, Domain.Core.Entities.Hotel.Hotel>, HotelService>();
        services.AddScoped<IAdditionalFeaturesRepository<Domain.Core.Entities.Hotel.Hotel>, AdditionalFeaturesRepository<Domain.Core.Entities.Hotel.Hotel>>();
    }
}
