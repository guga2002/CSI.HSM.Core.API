using GuestSide.Application.DTOs.FeedBacks;
using GuestSide.Core.Entities.Feedbacks;

namespace GuestSide.Application.Interface.Feadback
{
    public interface IFeadbackService:IService<Feedback, long>
    {
    }
}
