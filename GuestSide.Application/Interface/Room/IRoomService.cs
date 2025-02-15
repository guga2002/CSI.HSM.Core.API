using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Room;

namespace Core.Application.Interface.Room;

public interface IRoomService : IService<RoomsDto, RoomsResponseDto, long, Core.Entities.Room.Room>,
    IAdditionalFeatures<RoomsDto, RoomsResponseDto, long, Core.Entities.Room.Room>
{
    Task<RoomsResponseDto> GetRoomDetails(long roomId);
    Task<HotelResponse> GetHotelForRoom(long roomId);
}
