using Domain.Core.Entities.Staff;
using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Staff
{
    public interface IStaffSentimentRepository : IGenericRepository<StaffSentiment>
    {
        Task<IEnumerable<StaffSentiment>> GetSentimentsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffSentiment>> GetSentimentsByLabelAsync(string label, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffSentiment>> GetSentimentsByEmotionAsync(string emotion, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffSentiment>> GetRecentSentimentsAsync(int days, CancellationToken cancellationToken = default);

        Task<bool> UpdateSentimentLabelAsync(long sentimentId, string newLabel, CancellationToken cancellationToken = default);
        Task<bool> UpdateSentimentConfidenceAsync(long sentimentId, double newConfidence, CancellationToken cancellationToken = default);

        Task<double?> GetAverageSentimentScoreAsync(long staffId, CancellationToken cancellationToken = default);
        Task<IEnumerable<long>> GetNegativeSentimentStaffAsync(double threshold, CancellationToken cancellationToken = default);
    }
}