using Core.Core.Entities.FeedBacks;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.FeedBack
{
    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
        Task<List<Feedback>> GetallFeadbackForguest(long guestId);
        //add another method
    }
}
