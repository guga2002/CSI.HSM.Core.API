using AutoMapper;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Core.Entities.Room;

namespace Core.Application.Services.Room.Mapper;

public class RoomCategoryMapper:Profile
{
    public RoomCategoryMapper()
    {
        CreateMap<RoomCategoryDto, RoomCategory>().ReverseMap();
        CreateMap<RoomCategory, RoomCategoryResponseDto>().ReverseMap();
    }
}
