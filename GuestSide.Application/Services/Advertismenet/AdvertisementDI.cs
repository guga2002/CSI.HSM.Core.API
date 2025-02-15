using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;
using Core.Application.Interface.Advertisment;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Advertismenet.Mapper;
using Core.Core.Entities.Advertisements;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Advertisement;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Advertisement;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Advertismenet;

public static class AdvertisementDI
{
    public static void InjectAdvertisment(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<IGenericRepository<Advertisement>, AdvertisementRepository>();
        serviceProvider.AddScoped<IAdditionalFeaturesRepository<Advertisement>, AdditionalFeaturesRepository<Advertisement>>();
        serviceProvider.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
        serviceProvider.AddScoped<IAdvertismentService, AdvertisementService>();
        serviceProvider.AddScoped<IService<AdvertismentDto, AdvertismentResponseDto, long, Advertisement>, AdvertisementService>();
        serviceProvider.AddScoped<IAdditionalFeatures<AdvertismentDto, AdvertismentResponseDto, long, Advertisement>, AdvertisementService>();
        serviceProvider.AddAutoMapper(typeof(AdvertisementMapper));
    }
}
