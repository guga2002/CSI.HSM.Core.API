using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Advertisement;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Advertisement;
using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;
using Core.Application.Interface.AdvertiementType;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.AdvertisementType.Mapper;
using Core.Application.Services.AdvertisementType.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.AdvertisementType.Injection;

public static class AdvertismentTypeDI
{
    public static void AddAdvertisementType(this IServiceCollection collect)
    {
        collect.AddScoped<IGenericRepository<Common.Data.Entities.Advertisements.AdvertisementType>, AdvertisementTypeRepository>();
        collect.AddScoped<IAdvertisementTypeRepository, AdvertisementTypeRepository>();
        collect.AddScoped<IAdvertisementTypeService, AdvertisementTypeService>();
        collect.AddScoped<IService<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, Common.Data.Entities.Advertisements.AdvertisementType>, AdvertisementTypeService>();
        collect.AddScoped<IAdditionalFeatures<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, Common.Data.Entities.Advertisements.AdvertisementType>, AdvertisementTypeService>();
        collect.AddScoped<IAdditionalFeaturesRepository<Common.Data.Entities.Advertisements.AdvertisementType>, AdditionalFeaturesRepository<Common.Data.Entities.Advertisements.AdvertisementType>>();
        collect.AddAutoMapper(typeof(AdvertisementTypeMapper));
        // collect.AddScoped < ILogger<GenericService<AdvertisementTypeDto, long, GuestSide.Core.Entities.Advertisments.AdvertisementType>>>();
    }
}
