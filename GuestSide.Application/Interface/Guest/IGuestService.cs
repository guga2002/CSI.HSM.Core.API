using GuestSide.Application.DTOs.NewFolder;
using GuestSide.Core.Entities.Guest;

namespace GuestSide.Application.Interface.Guest
{
    public interface IGuestService:IService<GuestDto,long,Guests>
    {
    }
}
