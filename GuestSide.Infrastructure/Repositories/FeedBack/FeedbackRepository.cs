using Core.Core.Data;
using Core.Core.Entities.FeedBacks;
using Core.Core.Interfaces.FeedBack;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.FeedBack
{
    public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Feedback> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public async Task<List<Feedback>> GetallFeadbackForguest(long guestId)
        {
            var suchFeadbacks = await DbSet.Include(io => io.Task).
                ThenInclude(io => io!.Cart).
                ThenInclude(io => io!.Guest)
                .Where(io => io.Task.Cart.GuestId == guestId).ToListAsync();

            return suchFeadbacks;
        }
    }
}
