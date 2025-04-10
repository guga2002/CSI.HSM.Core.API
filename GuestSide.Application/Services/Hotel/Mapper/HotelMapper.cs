using AutoMapper;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;

namespace Core.Application.Services.Hotel.Mapper;

public class HotelMapper:Profile
{

    public HotelMapper()
    {
        CreateMap<HotelRequestDto, Domain.Core.Entities.Hotel.Hotel>().ReverseMap();
        CreateMap<HotelResponse, Domain.Core.Entities.Hotel.Hotel>().ReverseMap();
    }
}
