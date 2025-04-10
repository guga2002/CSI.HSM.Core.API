using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Staff;
using Domain.Core.Interfaces.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Staff
{
    public class StaffSentimentRepository : GenericRepository<StaffSentiment>, IStaffSentimentRepository
    {
        private readonly GuestSideDb _context;
        private readonly IRedisCash _redisCache;
        private readonly ILogger<StaffSentiment> _logger;

        public StaffSentimentRepository(GuestSideDb context, IRedisCash redisCache,
            IHttpContextAccessor httpContextAccessor, ILogger<StaffSentiment> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
            _context = context;
            _redisCache = redisCache;
            _logger = logger;
        }

        #region Sentiment Lookup & Filtering

        public async Task<IEnumerable<StaffSentiment>> GetSentimentsByStaffIdAsync(long staffId,
            CancellationToken cancellationToken = default)
        {
            return await _context.StaffSentiments.AsNoTracking()
                .Where(s => s.StaffId == staffId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffSentiment>> GetSentimentsByLabelAsync(string label,
            CancellationToken cancellationToken = default)
        {
            return await _context.StaffSentiments.AsNoTracking()
                .Where(s => s.SentimentLabel == label)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffSentiment>> GetSentimentsByEmotionAsync(string emotion,
            CancellationToken cancellationToken = default)
        {
            return await _context.StaffSentiments.AsNoTracking()
                .Where(s => s.Emotion == emotion)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<StaffSentiment>> GetRecentSentimentsAsync(int days,
            CancellationToken cancellationToken = default)
        {
            var fromDate = DateTime.UtcNow.AddDays(-days);
            return await _context.StaffSentiments.AsNoTracking()
                .Where(s => s.AnalysisDate >= fromDate)
                .ToListAsync(cancellationToken);
        }

        #endregion

        #region Sentiment Management

        public async Task<bool> UpdateSentimentLabelAsync(long sentimentId, string newLabel,
            CancellationToken cancellationToken = default)
        {
            var sentiment = await _context.StaffSentiments.FindAsync(new object[] { sentimentId }, cancellationToken);
            if (sentiment == null) return false;

            sentiment.SentimentLabel = newLabel;
            sentiment.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(sentimentId);
            return true;
        }

        public async Task<bool> UpdateSentimentConfidenceAsync(long sentimentId, double newConfidence,
            CancellationToken cancellationToken = default)
        {
            var sentiment = await _context.StaffSentiments.FindAsync(new object[] { sentimentId }, cancellationToken);
            if (sentiment == null) return false;

            sentiment.SentimentConfidence = newConfidence;
            sentiment.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            await InvalidateCache(sentimentId);
            return true;
        }

        #endregion

        #region AI-Driven Sentiment Analysis

        public async Task<double?> GetAverageSentimentScoreAsync(long staffId,
            CancellationToken cancellationToken = default)
        {
            return await _context.StaffSentiments
                .Where(s => s.StaffId == staffId)
                .Select(s => s.SentimentScore)
                .AverageAsync(cancellationToken);
        }

        public async Task<IEnumerable<long>> GetNegativeSentimentStaffAsync(double threshold,
            CancellationToken cancellationToken = default)
        {
            return await _context.StaffSentiments
                .Where(s => s.SentimentScore < threshold)
                .Select(s => s.StaffId)
                .Distinct()
                .ToListAsync(cancellationToken);
        }

        #endregion

        #region Caching Helpers

        private async Task<bool> InvalidateCache(long sentimentId)
        {
            var cacheKey = $"StaffSentiment_GetById_{sentimentId}";
            try
            {
                await _redisCache.RemoveCache(cacheKey);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error invalidating cache for key {CacheKey}", cacheKey);
                return false;
            }
        }

        #endregion
    }
}