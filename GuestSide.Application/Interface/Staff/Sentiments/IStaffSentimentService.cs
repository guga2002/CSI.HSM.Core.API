using Common.Data.Entities.Staff;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Staff.Sentiments
{
    public interface IStaffSentimentService : IService<StaffSentimentDto, StaffSentimentResponseDto, long, StaffSentiment>,
        IAdditionalFeatures<StaffSentimentDto, StaffSentimentResponseDto, long, StaffSentiment>
    {
        /// <summary>
        /// Get sentiment records by staff ID.
        /// </summary>
        Task<IEnumerable<StaffSentimentResponseDto>> GetSentimentsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get sentiment records by label.
        /// </summary>
        Task<IEnumerable<StaffSentimentResponseDto>> GetSentimentsByLabelAsync(string label, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get sentiment records by emotion.
        /// </summary>
        Task<IEnumerable<StaffSentimentResponseDto>> GetSentimentsByEmotionAsync(string emotion, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get recent sentiment records.
        /// </summary>
        Task<IEnumerable<StaffSentimentResponseDto>> GetRecentSentimentsAsync(int days, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update sentiment label.
        /// </summary>
        Task<bool> UpdateSentimentLabelAsync(long sentimentId, string newLabel, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update sentiment confidence score.
        /// </summary>
        Task<bool> UpdateSentimentConfidenceAsync(long sentimentId, double newConfidence, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the average sentiment score for a staff member.
        /// </summary>
        Task<double?> GetAverageSentimentScoreAsync(long staffId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a list of staff members with negative sentiment scores.
        /// </summary>
        Task<IEnumerable<long>> GetNegativeSentimentStaffAsync(double threshold, CancellationToken cancellationToken = default);
    }
}
