using AutoMapper;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;

namespace Core.Application.Services.Hotel.Mapper;

public class HotelMapper : Profile
{

    public HotelMapper()
    {
        CreateMap<HotelRequestDto, Common.Data.Entities.Hotel.Hotel>().ReverseMap();
        CreateMap<HotelResponse, Common.Data.Entities.Hotel.Hotel>().ReverseMap();
    }
}
