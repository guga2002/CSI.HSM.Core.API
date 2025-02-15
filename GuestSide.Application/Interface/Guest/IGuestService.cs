using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Guest;

namespace Core.Application.Interface.Guest;

public interface IGuestService : IService<GuestDto, GuestResponseDto, long, Guests>,
    IAdditionalFeatures<GuestDto, GuestResponseDto, long, Guests>
{
    Task<RoomsResponseDto> GetRoomByGuestId(long GuestId);
}
