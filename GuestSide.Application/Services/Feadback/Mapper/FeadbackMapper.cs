using AutoMapper;
using Common.Data.Entities.FeedBacks;
using Core.Application.DTOs.Request.FeedBacks;
using Core.Application.DTOs.Response.FeedBacks;

namespace Core.Application.Services.Feadback.Mapper;

public class FeadbackMapper : Profile
{
    public FeadbackMapper()
    {
        CreateMap<FeedbackDto, Feedback>().ReverseMap();
        CreateMap<FeedbackResponseDto, Feedback>().ReverseMap();
    }
}
