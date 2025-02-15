using AutoMapper;
using Core.Application.DTOs.Request.FeedBacks;
using Core.Application.DTOs.Response.FeedBacks;
using Core.Application.Interface.Feadback;
using Core.Application.Services;
using Core.Core.Entities.FeedBacks;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.FeedBack;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Feadback;
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
        var res = await _feedbackRepository.GetallFeadbackForguest(guestId);
        if (res.Count > 0)
        {
            return _mapper.Map<List<FeedbackResponseDto>>(res);
        }
        return null;
    }
}