using AutoMapper;
using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Response.Advertisment;
using GuestSide.Core.Entities.Advertisements;

namespace Core.Application.Services.Advertismenet.Mapper
{
    public class AdvertisementMapper:Profile
    {
        public AdvertisementMapper()
        {
            CreateMap<Advertisements, AdvertismentDto>();
            CreateMap<AdvertismentResponseDto, Advertisements>();
        }
    }
}
