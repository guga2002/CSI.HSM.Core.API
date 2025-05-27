using AutoMapper;
using Common.Data.Entities.Promo;
using Core.Application.DTOs.Request.Promo;
using Core.Application.DTOs.Response.Promo;

namespace Core.Application.Services.Promo.Mapper;

public class PromoCodeMapper : Profile
{
    public PromoCodeMapper()
    {
        CreateMap<PromoCode, PromoCodeDto>().ReverseMap();
        CreateMap<PromoCode, PromoCodeResponse>().ReverseMap();
    }
}
