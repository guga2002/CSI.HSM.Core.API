using AutoMapper;
using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;

namespace Core.Application.Services.Hotel.Mapper;

public class HotelMapper:Profile
{

    public HotelMapper()
    {
        CreateMap<HotelRequestDto, GuestSide.Core.Entities.Hotel.Hotel>().ReverseMap();
        CreateMap<HotelResponse, GuestSide.Core.Entities.Hotel.Hotel>().ReverseMap();
    }
}
