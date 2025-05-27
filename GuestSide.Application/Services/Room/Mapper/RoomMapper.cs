using AutoMapper;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;

namespace Core.Application.Services.Room.Mapper;

public class RoomMapper : Profile
{
    public RoomMapper()
    {
        CreateMap<RoomsDto, Common.Data.Entities.Room.Room>().ReverseMap();
        CreateMap<Common.Data.Entities.Room.Room, RoomsResponseDto>().ReverseMap();
    }
}
