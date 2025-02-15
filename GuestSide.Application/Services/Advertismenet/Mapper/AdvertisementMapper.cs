using AutoMapper;
using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;
using Core.Core.Entities.Advertisements;

namespace Core.Application.Services.Advertismenet.Mapper;

public class AdvertisementMapper:Profile
{
    public AdvertisementMapper()
    {
        CreateMap<Advertisement, AdvertismentDto>();
        CreateMap<AdvertismentResponseDto, Advertisement>();
    }
}
