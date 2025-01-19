using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Advertismenet.Mapper;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;
using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Response.Advertisment;
using GuestSide.Application.Interface.Advertisment;
using GuestSide.Core.Entities.Advertisements;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Advertisement;
using GuestSide.Infrastructure.Repositories.Advertisement;
using Microsoft.Extensions.DependencyInjection;

namespace GuestSide.Application.Services.Advertismenet;

public static class AdvertisementDI
{
    public static void InjectAdvertisment(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<IGenericRepository<Advertisements>,AdvertisementRepository>();
        serviceProvider.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
        serviceProvider.AddScoped<IAdvertismentService, AdvertisementService>();
        serviceProvider.AddScoped<IService<AdvertismentDto,AdvertismentResponseDto, long, Advertisements>, AdvertisementService>();
        serviceProvider.AddScoped<IAdditionalFeatures<AdvertismentDto, AdvertismentResponseDto, long, Advertisements>, AdvertisementService>();
        serviceProvider.AddScoped<IAdditionalFeaturesRepository<Advertisements>, AdditionalFeaturesRepository<Advertisements>>();
        serviceProvider.AddAutoMapper(typeof(AdvertisementMapper));
    }
}
