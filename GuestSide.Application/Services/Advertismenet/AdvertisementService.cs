using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Response.Advertisment;
using GuestSide.Application.Interface.Advertisment;
using GuestSide.Core.Entities.Advertisements;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Advertismenet;

public class AdvertisementService : GenericService<AdvertismentDto, AdvertismentResponseDto, long, Advertisements>, IAdvertismentService
{
    public AdvertisementService(IMapper mapper, 
        IGenericRepository<Advertisements> repository, 
        ILogger<GenericService<AdvertismentDto, AdvertismentResponseDto, long, Advertisements>> logger, 
        IAdditionalFeaturesRepository<Advertisements> additioalFeatures) 
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
