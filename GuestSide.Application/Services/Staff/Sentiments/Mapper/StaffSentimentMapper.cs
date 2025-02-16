using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Core.Entities.Staff;

namespace Core.Application.Services.Staff.Sentiments.Mapper
{
    public class StaffSentimentMapper:Profile
    {
        public StaffSentimentMapper()
        {
            CreateMap<StaffSentiment, StaffSentimentResponseDto>().ReverseMap();
            CreateMap<StaffSentiment, StaffSentimentDto>().ReverseMap();
        }
    }
}
