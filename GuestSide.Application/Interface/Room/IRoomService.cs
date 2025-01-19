using Core.Application.Interface.GenericContracts;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Core.Entities.Room;

namespace GuestSide.Application.Interface.Room
{
    public interface IRoomService:IService<RoomsDto,RoomsResponseDto,long,Rooms>
    {
    }
}
