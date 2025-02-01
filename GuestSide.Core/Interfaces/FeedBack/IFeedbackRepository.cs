using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Interfaces.AbstractInterface;

namespace GuestSide.Core.Interfaces.FeedBack
{
    public interface IFeedbackRepository:IGenericRepository<Feedback>
    {
        Task<List<Feedback>> GetallFeadbackForguest(long guestId);
        //add another method
    }
}
