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
        public FeedbackRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Feedback> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        /// <summary>
        /// Get all feedbacks related to a specific task
        /// </summary>
        public async Task<IEnumerable<Feedback>> GetFeedbacksByTaskIdAsync(long taskId)
        {
            return await DbSet
                .Where(f => f.TaskId == taskId)
                .OrderByDescending(f => f.FeedbackDate)
                .ToListAsync();
        }

        /// <summary>
        /// Get feedbacks within a specific rating range
        /// </summary>
        public async Task<IEnumerable<Feedback>> GetFeedbacksByRatingAsync(int minRating, int maxRating)
        {
            return await DbSet
                .Where(f => f.Rating >= minRating && f.Rating <= maxRating)
                .OrderByDescending(f => f.FeedbackDate)
                .ToListAsync();
        }

        /// <summary>
        /// Get feedbacks within a specific date range
        /// </summary>
        public async Task<IEnumerable<Feedback>> GetFeedbacksByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await DbSet
                .Where(f => f.FeedbackDate >= startDate && f.FeedbackDate <= endDate)
                .OrderByDescending(f => f.FeedbackDate)
                .ToListAsync();
        }

        /// <summary>
        /// Get all feedbacks in a specific language
        /// </summary>
        public async Task<IEnumerable<Feedback>> GetFeedbacksByLanguageAsync(string languageCode)
        {
            return await DbSet
                .Where(f => f.LanguageCode == languageCode)
                .OrderByDescending(f => f.FeedbackDate)
                .ToListAsync();
        }

        /// <summary>
        /// Get a feedback entry by its correlation ID
        /// </summary>
        public async Task<Feedback> GetFeedbackByCorrelationIdAsync(Guid correlationId)
        {
            return await DbSet.FirstOrDefaultAsync(f => f.CorrelationId == correlationId);
        }

        /// <summary>
        /// Update the rating of a feedback entry using its correlation ID
        /// </summary>
        public async Task<bool> UpdateFeedbackRatingAsync(Guid correlationId, int newRating)
        {
            var feedback = await DbSet.FirstOrDefaultAsync(f => f.CorrelationId == correlationId);
            if (feedback == null) return false;

            feedback.Rating = newRating;
            Context.Update(feedback);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Delete a feedback entry using its correlation ID
        /// </summary>
        public async Task<bool> DeleteFeedbackByCorrelationIdAsync(Guid correlationId)
        {
            var feedback = await DbSet.FirstOrDefaultAsync(f => f.CorrelationId == correlationId);
            if (feedback == null) return false;

            DbSet.Remove(feedback);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
