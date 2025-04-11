using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Domain.Core.Entities.Item;

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
