using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Response.Advertisment;
using GuestSide.Core.Entities.Advertisements;

namespace GuestSide.Application.Interface.Advertisment
{
    public interface IAdvertismentService:IService<AdvertismentDto,AdvertismentResponseDto, long,Advertisements>
    {
    }
}
