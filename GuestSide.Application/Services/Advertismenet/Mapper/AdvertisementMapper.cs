using AutoMapper;
using Core.Application.DTOs.Request.Advertisment;
using Domain.Application.DTOs.Response.Advertisment;
using Domain.Core.Entities.Advertisements;

namespace Core.Application.Services.Advertismenet.Mapper;

public class AdvertisementMapper : Profile
{
    public AdvertisementMapper()
    {
        CreateMap<Advertisement, AdvertismentDto>().ReverseMap();
        CreateMap<AdvertismentResponseDto, Advertisement>().ReverseMap();
    }
}
