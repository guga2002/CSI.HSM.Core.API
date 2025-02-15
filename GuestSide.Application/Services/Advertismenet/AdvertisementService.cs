using AutoMapper;
using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;
using Core.Application.Interface.Advertisment;
using Core.Core.Entities.Advertisements;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Advertismenet;

public class AdvertisementService : GenericService<AdvertismentDto, AdvertismentResponseDto, long, Advertisement>, IAdvertismentService
{
    public AdvertisementService(IMapper mapper,
        IGenericRepository<Advertisement> repository,
        ILogger<GenericService<AdvertismentDto, AdvertismentResponseDto, long, Advertisement>> logger,
        IAdditionalFeaturesRepository<Advertisement> additioalFeatures)
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
