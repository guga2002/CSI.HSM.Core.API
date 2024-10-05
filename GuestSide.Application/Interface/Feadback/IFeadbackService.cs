using GuestSide.Application.DTOs.FeedBacks;
using GuestSide.Application.Services.Feadback;
using GuestSide.Core.Entities.Feedbacks;

namespace GuestSide.Application.Interface.Feadback
{
    public interface IFeadbackService:IService<FeedbackDto, long, Feedback>
    {
    }
}
