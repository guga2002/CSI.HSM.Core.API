using AutoMapper;
using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;
using Core.Application.Interface.AdvertiementType;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.AdvertisementType;

public class AdvertisementTypeService : GenericService<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, Core.Entities.Advertisements.AdvertisementType>, IAdvertisementTypeService
{
    public AdvertisementTypeService(
        IMapper mapper,
        IGenericRepository<Core.Entities.Advertisements.AdvertisementType> repository,
        ILogger<GenericService<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, Core.Entities.Advertisements.AdvertisementType>> logger,
        IAdditionalFeaturesRepository<Core.Entities.Advertisements.AdvertisementType> additioalFeatures)
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
