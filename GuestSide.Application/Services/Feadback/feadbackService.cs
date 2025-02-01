using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.FeedBacks;
using GuestSide.Application.DTOs.Response.FeedBacks;
using GuestSide.Application.Interface.Feadback;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.FeedBack;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Feadback;
public class feadbackService : GenericService<FeedbackDto, FeedbackResponseDto, long, Feedback>, IFeadbackService
{
    private readonly IMapper _mapper;
    private readonly IFeedbackRepository _feedbackRepository;
    public feadbackService(IMapper mapper,
        IGenericRepository<Feedback> repository,
        ILogger<GenericService<FeedbackDto, FeedbackResponseDto, long, Feedback>> logger,
        IAdditionalFeaturesRepository<Feedback> additioalFeatures,
        IFeedbackRepository feedbackRepository)
        : base(mapper, repository, logger, additioalFeatures)
    {
        _mapper = mapper;
        _feedbackRepository = feedbackRepository;
    }

    public async Task<List<FeedbackResponseDto>> GetallFeadbackForguest(long guestId)
    {
       var res=await _feedbackRepository.GetallFeadbackForguest(guestId);
        if (res.Count > 0)
        {
            return _mapper.Map<List<FeedbackResponseDto>>(res);
        }
        return null;
    }
}