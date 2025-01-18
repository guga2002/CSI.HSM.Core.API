using AutoMapper;
using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Response.Advertisment;

namespace Core.Application.Services.AdvertisementType.Mapper
{
    public class AdvertisementTypeMapper:Profile
    {
        public AdvertisementTypeMapper()
        {
            CreateMap<AdvertisementTypeDto, GuestSide.Core.Entities.Advertisments.AdvertisementType>().ReverseMap();
            CreateMap<GuestSide.Core.Entities.Advertisments.AdvertisementType, AdvertisementTypeResponseDto>().ReverseMap();
        }
    }
}
