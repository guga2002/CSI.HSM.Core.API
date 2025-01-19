using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.FeedBacks;
using GuestSide.Application.DTOs.Response.FeedBacks;
using GuestSide.Application.Interface.Feadback;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Feadback;
public class feadbackService : GenericService<FeedbackDto, FeedbackResponseDto, long, Feedback>, IFeadbackService
{
    public feadbackService(IMapper mapper,
        IGenericRepository<Feedback> repository, 
        ILogger<GenericService<FeedbackDto, FeedbackResponseDto, long, Feedback>> logger, 
        IAdditioalFeatures<Feedback> additioalFeatures) 
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}