using GuestSide.Application.DTOs.FeedBacks;
using GuestSide.Application.Interface.Feadback;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Interfaces.AbstractInterface;

namespace GuestSide.Application.Services.Feadback
{
    public class feadbackService : GenericService<Feedback, long>, IFeadbackService
    {
        public feadbackService(IGenericRepository<Feedback> servic) : base(servic)
        {
        }
    }
}
