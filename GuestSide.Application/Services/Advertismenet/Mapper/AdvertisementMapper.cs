using AutoMapper;
using Common.Data.Entities.Advertisements;
using Core.Application.DTOs.Request.Advertisment;

namespace Core.Application.Services.Advertismenet.Mapper;

public class AdvertisementMapper : Profile
{
    public AdvertisementMapper()
    {
        CreateMap<Advertisement, AdvertismentDto>().ReverseMap();
        CreateMap<AdvertismentResponseDto, Advertisement>().ReverseMap();
    }
}
