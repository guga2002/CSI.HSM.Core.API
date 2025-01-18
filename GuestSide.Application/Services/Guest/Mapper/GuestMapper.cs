using AutoMapper;
using GuestSide.Application.DTOs.Request.Guest;
using GuestSide.Application.DTOs.Response.Guest;
using GuestSide.Core.Entities.Guest;

namespace Core.Application.Services.Guest.Mapper;

public class GuestMapper:Profile
{

    public GuestMapper()
    {
         CreateMap<GuestDto, Guests>().ReverseMap();
        CreateMap<GuestResponseDto, Guests>().ReverseMap();
    }
}
