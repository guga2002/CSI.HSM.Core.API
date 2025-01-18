using AutoMapper;
using GuestSide.Application.DTOs.Request.FeedBacks;
using GuestSide.Application.DTOs.Response.FeedBacks;
using GuestSide.Core.Entities.Feedbacks;

namespace Core.Application.Services.Feadback.Mapper;

public class FeadbackMapper: Profile
{
    public FeadbackMapper()
    {
        CreateMap<FeedbackDto,Feedback>().ReverseMap();
        CreateMap<FeedbackResponseDto, Feedback>().ReverseMap();
    }
}
