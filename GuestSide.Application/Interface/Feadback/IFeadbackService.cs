using Core.Application.DTOs.Request.FeedBacks;
using Core.Application.DTOs.Response.FeedBacks;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.FeedBacks;

namespace Core.Application.Interface.Feadback;

public interface IFeadbackService : IService<FeedbackDto, FeedbackResponseDto, long, Feedback>,
    IAdditionalFeatures<FeedbackDto, FeedbackResponseDto, long, Feedback>
{
    Task<List<FeedbackResponseDto>> GetallFeadbackForguest(long guestId);
}
