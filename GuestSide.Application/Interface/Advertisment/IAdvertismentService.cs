using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Advertisements;

namespace Core.Application.Interface.Advertisment;

public interface IAdvertismentService : IService<AdvertismentDto, AdvertismentResponseDto, long, Advertisements>,
    IAdditionalFeatures<AdvertismentDto, AdvertismentResponseDto, long, Advertisements>
{
}
