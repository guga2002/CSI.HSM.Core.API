using GuestSide.Application.DTOs.Request.FeedBacks;
using GuestSide.Application.DTOs.Response.FeedBacks;
using GuestSide.Core.Entities.Feedbacks;

namespace GuestSide.Application.Interface.Feadback
{
    public interface IFeadbackService:IService<FeedbackDto, FeedbackResponseDto, long, Feedback>
    {
    }
}
