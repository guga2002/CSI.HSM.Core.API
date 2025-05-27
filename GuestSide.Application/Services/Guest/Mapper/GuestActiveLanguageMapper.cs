using AutoMapper;
using Common.Data.Entities.Guest;
using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;

namespace Core.Application.Services.Guest.Mapper;

public class GuestActiveLanguageMapper : Profile
{
    public GuestActiveLanguageMapper()
    {
        CreateMap<GuestActiveLanguageDto, GuestActiveLanguage>().ReverseMap();
        CreateMap<GuestActiveLanguageResponseDto, GuestActiveLanguage>().ReverseMap();

    }
}
