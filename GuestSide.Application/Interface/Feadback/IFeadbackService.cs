using Core.Application.DTOs.Request.FeedBacks;
using Core.Application.DTOs.Response.FeedBacks;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.FeedBacks;

namespace Core.Application.Interface.FeedBack
{
    public interface IFeadbackService : IService<FeedbackDto, FeedbackResponseDto, long, Feedback>,
        IAdditionalFeatures<FeedbackDto, FeedbackResponseDto, long, Feedback>
    {
        /// <summary>
        /// Get feedbacks by task ID.
        /// </summary>
        Task<IEnumerable<FeedbackResponseDto>> GetFeedbacksByTaskIdAsync(long taskId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get feedbacks within a specific rating range.
        /// </summary>
        Task<IEnumerable<FeedbackResponseDto>> GetFeedbacksByRatingAsync(int minRating, int maxRating, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get feedbacks within a specific date range.
        /// </summary>
        Task<IEnumerable<FeedbackResponseDto>> GetFeedbacksByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get feedbacks based on language.
        /// </summary>
        Task<IEnumerable<FeedbackResponseDto>> GetFeedbacksByLanguageAsync(string languageCode, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get feedback by its unique correlation ID.
        /// </summary>
        Task<FeedbackResponseDto?> GetFeedbackByCorrelationIdAsync(Guid correlationId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update feedback rating by correlation ID.
        /// </summary>
        Task<bool> UpdateFeedbackRatingAsync(Guid correlationId, int newRating, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete feedback by correlation ID.
        /// </summary>
        Task<bool> DeleteFeedbackByCorrelationIdAsync(Guid correlationId, CancellationToken cancellationToken = default);
    }
}
