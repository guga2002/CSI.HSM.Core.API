using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Advertisements;

namespace Core.Application.Interface.AdvertiementType;

public interface IAdvertisementTypeService : IService<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType>,
    IAdditionalFeatures<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType>
{
}
