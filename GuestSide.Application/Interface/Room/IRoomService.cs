using Core.Application.Interface.GenericContracts;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Core.Entities.Room;

namespace GuestSide.Application.Interface.Room;

public interface IRoomService:IService<RoomsDto,RoomsResponseDto,long,Rooms>,
    IAdditionalFeatures<RoomsDto, RoomsResponseDto, long, Rooms>
{
    Task<RoomsResponseDto> GetRoomDetails(long roomId);
    Task<HotelResponse> GetHotelForRoom(long roomId);
}
