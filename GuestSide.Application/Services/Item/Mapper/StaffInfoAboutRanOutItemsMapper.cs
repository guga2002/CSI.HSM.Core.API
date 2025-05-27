using AutoMapper;
using Common.Data.Entities.Item;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;

namespace Core.Application.Services.Item.Mapper
{
    public class StaffInfoAboutRanOutItemsMapper : Profile
    {
        public StaffInfoAboutRanOutItemsMapper()
        {
            CreateMap<StaffInfoAboutRanOutItems, StaffInfoAboutRanOutItemsResponseDto>().ReverseMap();
            CreateMap<StaffInfoAboutRanOutItems, StaffInfoAboutRanOutItemsDto>().ReverseMap();
        }
    }
}
