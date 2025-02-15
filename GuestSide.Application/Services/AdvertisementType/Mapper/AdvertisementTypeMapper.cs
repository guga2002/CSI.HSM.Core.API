using AutoMapper;
using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;

namespace Core.Application.Services.AdvertisementType.Mapper;

public class AdvertisementTypeMapper:Profile
{
    public AdvertisementTypeMapper()
    {
        CreateMap<AdvertisementTypeDto, Core.Entities.Advertisements.AdvertisementType>().ReverseMap();
        CreateMap<Core.Entities.Advertisements.AdvertisementType, AdvertisementTypeResponseDto>().ReverseMap();
    }
}
