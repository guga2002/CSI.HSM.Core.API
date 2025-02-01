using Core.Application.Interface.GenericContracts;
using GuestSide.Application.DTOs.Request.FeedBacks;
using GuestSide.Application.DTOs.Response.FeedBacks;
using GuestSide.Core.Entities.Feedbacks;

namespace GuestSide.Application.Interface.Feadback;

public interface IFeadbackService:IService<FeedbackDto, FeedbackResponseDto, long, Feedback>,
    IAdditionalFeatures<FeedbackDto, FeedbackResponseDto, long, Feedback>
{
    Task<List<FeedbackResponseDto>> GetallFeadbackForguest(long guestId);
}
