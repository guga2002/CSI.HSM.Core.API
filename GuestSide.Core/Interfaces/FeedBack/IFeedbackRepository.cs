using Core.Core.Entities.FeedBacks;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.FeedBack
{
    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
        Task<IEnumerable<Feedback>> GetFeedbacksByTaskIdAsync(long taskId);
        Task<IEnumerable<Feedback>> GetFeedbacksByRatingAsync(int minRating, int maxRating);
        Task<IEnumerable<Feedback>> GetFeedbacksByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Feedback>> GetFeedbacksByLanguageAsync(string languageCode);
        Task<Feedback> GetFeedbackByCorrelationIdAsync(Guid correlationId);
        Task<bool> UpdateFeedbackRatingAsync(Guid correlationId, int newRating);
        Task<bool> DeleteFeedbackByCorrelationIdAsync(Guid correlationId);
    }
}