using AutoMapper;
using GuestSide.Application.DTOs.Request.FeedBacks;
using GuestSide.Application.DTOs.Response.FeedBacks;
using GuestSide.Application.Interface.Feadback;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Feadback
{
    public class feadbackService : GenericService<FeedbackDto,FeedbackResponseDto, long, Feedback>, IFeadbackService
    {

        public feadbackService(IGenericRepository<Feedback> servic,  IMapper Map, ILogger<GenericService<FeedbackDto,FeedbackResponseDto, long, Feedback>> log) : base(Map, servic, log)
        {
        }
    }
}
