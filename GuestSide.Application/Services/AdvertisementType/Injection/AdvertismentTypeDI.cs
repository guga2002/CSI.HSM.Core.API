using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;
using Core.Application.Interface.AdvertiementType;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.AdvertisementType.Mapper;
using Core.Application.Services.AdvertisementType.Service;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Advertisement;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Advertisement;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.AdvertisementType.Injection;

public static class AdvertismentTypeDI
{
    public static void AddAdvertisementType(this IServiceCollection collect)
    {
        collect.AddScoped<IGenericRepository<Core.Entities.Advertisements.AdvertisementType>, AdvertisementTypeRepository>();
        collect.AddScoped<IAdvertisementTypeRepository, AdvertisementTypeRepository>();
        collect.AddScoped<IAdvertisementTypeService, AdvertisementTypeService>();
        collect.AddScoped<IService<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, Core.Entities.Advertisements.AdvertisementType>, AdvertisementTypeService>();
        collect.AddScoped<IAdditionalFeatures<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, Core.Entities.Advertisements.AdvertisementType>, AdvertisementTypeService>();
        collect.AddScoped<IAdditionalFeaturesRepository<Core.Entities.Advertisements.AdvertisementType>, AdditionalFeaturesRepository<Core.Entities.Advertisements.AdvertisementType>>();
        collect.AddAutoMapper(typeof(AdvertisementTypeMapper));
        // collect.AddScoped < ILogger<GenericService<AdvertisementTypeDto, long, GuestSide.Core.Entities.Advertisments.AdvertisementType>>>();
    }
}
