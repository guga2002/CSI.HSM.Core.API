using AutoMapper;
using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;

namespace Core.Application.Services.AdvertisementType.Mapper;

public class AdvertisementTypeMapper : Profile
{
    public AdvertisementTypeMapper()
    {
        CreateMap<AdvertisementTypeDto, Common.Data.Entities.Advertisements.AdvertisementType>().ReverseMap();
        CreateMap<Common.Data.Entities.Advertisements.AdvertisementType, AdvertisementTypeResponseDto>().ReverseMap();
    }
}
