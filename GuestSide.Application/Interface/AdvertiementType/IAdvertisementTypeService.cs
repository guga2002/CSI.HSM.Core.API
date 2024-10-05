using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Core.Entities.Advertisments;

namespace GuestSide.Application.Interface.AdvertiementType
{
    public interface IAdvertisementTypeService:IService<AdvertisementTypeDto, long, GuestSide.Core.Entities.Advertisments.AdvertisementType>
    {
    }
}
