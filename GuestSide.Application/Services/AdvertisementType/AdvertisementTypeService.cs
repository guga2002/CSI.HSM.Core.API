using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Response.Advertisment;
using GuestSide.Application.Interface.AdvertiementType;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.AdvertisementType;

public class AdvertisementTypeService : GenericService<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, GuestSide.Core.Entities.Advertisments.AdvertisementType>, IAdvertisementTypeService
{
    public AdvertisementTypeService(
        IMapper mapper, 
        IGenericRepository<Core.Entities.Advertisments.AdvertisementType> repository, 
        ILogger<GenericService<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, Core.Entities.Advertisments.AdvertisementType>> logger, 
        IAdditioalFeatures<Core.Entities.Advertisments.AdvertisementType> additioalFeatures) 
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
