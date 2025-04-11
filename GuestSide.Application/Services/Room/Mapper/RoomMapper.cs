using AutoMapper;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;

namespace Core.Application.Services.Room.Mapper;

public class RoomMapper:Profile
{
    public RoomMapper()
    {
        CreateMap<RoomsDto, Domain.Core.Entities.Room.Room>().ReverseMap();
        CreateMap<Domain.Core.Entities.Room.Room, RoomsResponseDto>().ReverseMap();
    }
}
