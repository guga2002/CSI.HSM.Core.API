using AutoMapper;
using GuestSide.Application.Commands.Create.Advertisment;
using GuestSide.Application.Commands.Update.Advertisment;
using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Core.Entities.Advertisements;

namespace GuestSide.Application.AutoMappObjects
{
    public class AutoMapperForGuestSide:Profile
    {

        public AutoMapperForGuestSide()
        {
            //advertisment
            CreateMap<Advertisements, AdvertismentDto>().ReverseMap();
            CreateMap<CreateAdvertisementCommand,AdvertismentDto>().ReverseMap();
            CreateMap<UpdateAdvertisementCommand, AdvertismentDto>().ReverseMap();
            CreateMap<UpdateAdvertisementCommand, Advertisements>().ReverseMap();
            CreateMap<CreateAdvertisementCommand,Advertisements>().ReverseMap();


        }
    }
}
