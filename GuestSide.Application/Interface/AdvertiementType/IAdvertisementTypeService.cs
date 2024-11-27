using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Response.Advertisment;

namespace GuestSide.Application.Interface.AdvertiementType
{
    public interface IAdvertisementTypeService:IService<AdvertisementTypeDto,AdvertisementTypeResponseDto, long, GuestSide.Core.Entities.Advertisments.AdvertisementType>
    {
    }
}
