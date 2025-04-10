using AutoMapper;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Domain.Core.Entities.Room;

namespace Core.Application.Services.Room.Mapper;

public class RoomCategoryMapper:Profile
{
    public RoomCategoryMapper()
    {
        CreateMap<RoomCategoryDto, RoomCategory>().ReverseMap();
        CreateMap<RoomCategory, RoomCategoryResponseDto>().ReverseMap();
    }
}
