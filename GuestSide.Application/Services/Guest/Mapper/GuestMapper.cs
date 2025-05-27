using AutoMapper;
using Common.Data.Entities.Guest;
using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;

namespace Core.Application.Services.Guest.Mapper;

public class GuestMapper : Profile
{

    public GuestMapper()
    {
        CreateMap<GuestDto, Guests>().ReverseMap();
        CreateMap<GuestResponseDto, Guests>().ReverseMap();
    }
}
