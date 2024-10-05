using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Core.Entities.Advertisements;
using GuestSide.Core.Interfaces.Advertisement;

namespace GuestSide.Application.Interface.Advertisment
{
    public interface IAdvertismentService:IService<Advertisements,long>
    {
    }
}
