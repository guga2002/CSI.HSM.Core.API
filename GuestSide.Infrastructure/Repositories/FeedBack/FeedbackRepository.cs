using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.FeedBacks;
using Domain.Core.Interfaces.FeedBack;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.FeedBack;

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
            .OrderByDescending(f => f.CreatedAt)
            .ToListAsync();
    }

    /// <summary>
    /// Get feedbacks within a specific rating range
    /// </summary>
    public async Task<IEnumerable<Feedback>> GetFeedbacksByRatingAsync(int minRating, int maxRating)
    {
        return await DbSet
            .Where(f => f.Rating >= minRating && f.Rating <= maxRating)
            .OrderByDescending(f => f.CreatedAt)
            .ToListAsync();
    }

    /// <summary>
    /// Get feedbacks within a specific date range
    /// </summary>
    public async Task<IEnumerable<Feedback>> GetFeedbacksByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await DbSet
            .Where(f => f.CreatedAt >= startDate && f.CreatedAt <= endDate)
            .OrderByDescending(f => f.CreatedAt)
            .ToListAsync();
    }

    /// <summary>
    /// Get all feedbacks in a specific language
    /// </summary>
    public async Task<IEnumerable<Feedback>> GetFeedbacksByLanguageAsync(string languageCode)
    {
        return await DbSet
            .Where(f => f.LanguageCode == languageCode)
            .OrderByDescending(f => f.CreatedAt)
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

    public async Task<IEnumerable<Feedback>> GetFeedbacksByUserId(long userId)
    {
        return await DbSet
            .Include(io => io.Task)
            .ThenInclude(io => io.Cart)
            .Where(io => io.Task != null && io.Task.Cart != null && io.Task.Cart.GuestId == userId)
            .ToListAsync();
    }

}
