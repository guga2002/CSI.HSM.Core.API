using AutoMapper;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Core.Core.Entities.Room;

namespace Core.Application.Services.Room.Mapper;

public class RoomMapper:Profile
{
    public RoomMapper()
    {
        CreateMap<RoomsDto, Core.Entities.Room.Room>().ReverseMap();
        CreateMap<Core.Entities.Room.Room, RoomCategoryResponseDto>().ReverseMap();
    }
}
