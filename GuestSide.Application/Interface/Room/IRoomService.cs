using GuestSide.Application.DTOs.Room;
using GuestSide.Core.Entities.Room;

namespace GuestSide.Application.Interface.Room
{
    public interface IRoomService:IService<RoomsDto,long,Rooms>
    {
    }
}
