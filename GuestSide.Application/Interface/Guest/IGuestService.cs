using Core.Application.Interface.GenericContracts;
using GuestSide.Application.DTOs.Request.Guest;
using GuestSide.Application.DTOs.Response.Guest;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Core.Entities.Guest;

namespace GuestSide.Application.Interface.Guest;

public interface IGuestService:IService<GuestDto,GuestResponseDto,long,Guests>,
    IAdditionalFeatures<GuestDto, GuestResponseDto, long, Guests>
{
    Task<RoomsResponseDto> GetRoomByGuestId(long GuestId);
}
