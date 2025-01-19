using AutoMapper;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Core.Entities.Room;

namespace Core.Application.Services.Room.Mapper;

public class RoomMapper:Profile
{
    public RoomMapper()
    {
        CreateMap<RoomsDto, Rooms>().ReverseMap();
        CreateMap<Rooms, RoomCategoryResponseDto>().ReverseMap();
    }
}
