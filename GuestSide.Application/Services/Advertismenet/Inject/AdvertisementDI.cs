using Core.Application.DTOs.Request.Advertisment;
using Core.Application.Interface.Advertisment;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Advertismenet.Mapper;
using Core.Application.Services.Advertismenet.Service;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Advertisement;
using Domain.Application.DTOs.Response.Advertisment;
using Domain.Core.Entities.Advertisements;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Advertisement;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Advertismenet.Inject;

public static class AdvertisementDI
{
    public static void InjectAdvertisment(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<IGenericRepository<Advertisement>, AdvertisementRepository>();
        serviceProvider.AddScoped<IAdditionalFeaturesRepository<Advertisement>, AdditionalFeaturesRepository<Advertisement>>();
        serviceProvider.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
        serviceProvider.AddScoped<IAdvertisementService, AdvertisementService>();
        serviceProvider.AddScoped<IService<AdvertismentDto, AdvertismentResponseDto, long, Advertisement>, AdvertisementService>();
        serviceProvider.AddScoped<IAdditionalFeatures<AdvertismentDto, AdvertismentResponseDto, long, Advertisement>, AdvertisementService>();
        serviceProvider.AddAutoMapper(typeof(AdvertisementMapper));
    }
}
