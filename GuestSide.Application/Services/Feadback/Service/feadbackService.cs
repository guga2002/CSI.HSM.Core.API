using AutoMapper;
using Core.Application.DTOs.Request.FeedBacks;
using Core.Application.DTOs.Response.FeedBacks;
using Core.Application.Interface.Feadback;
using Core.Application.Services;
using Domain.Core.Entities.FeedBacks;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.FeedBack;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Core.Application.Services.Feadback.Service
{
    public class FeedbackService : GenericService<FeedbackDto, FeedbackResponseDto, long, Feedback>, IFeadbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FeedbackService> _logger;
        private static readonly Regex LanguageCodeRegex = new(@"^[a-zA-Z]{2,3}(-[a-zA-Z]{2,3})?$");

        public FeedbackService(
            IMapper mapper,
            IFeedbackRepository feedbackRepository,
            ILogger<FeedbackService> logger,
            IGenericRepository<Feedback> repository,
            IAdditionalFeaturesRepository<Feedback> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
            _logger = logger;
        }

        private void ValidatePositiveId(long id, string paramName)
        {
            if (id <= 0)
            {
                _logger.LogWarning("{ParameterName} must be a positive number.", paramName);
                throw new ArgumentException($"{paramName} must be greater than zero.", paramName);
            }
        }

        private void ValidateRating(int rating)
        {
            if (rating < 1 || rating > 5)  // Modify range if needed (e.g., 1-10)
            {
                _logger.LogWarning("Invalid rating: {Rating}", rating);
                throw new ArgumentException("Rating must be between 1 and 5.");
            }
        }

        private void ValidateDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                _logger.LogWarning("Invalid date range: {StartDate} - {EndDate}", startDate, endDate);
                throw new ArgumentException("Start date must be before or equal to the end date.");
            }
        }

        private void ValidateLanguageCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code) || !LanguageCodeRegex.IsMatch(code))
            {
                _logger.LogWarning("Invalid language code format: {Code}", code);
                throw new ArgumentException("Invalid language code format. Expected format: 'en', 'fr', 'es', or 'en-US'.");
            }
        }

        public async Task<IEnumerable<FeedbackResponseDto>> GetFeedbacksByTaskIdAsync(long taskId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(taskId, nameof(taskId));

            var feedbacks = await _feedbackRepository.GetFeedbacksByTaskIdAsync(taskId);
            return _mapper.Map<IEnumerable<FeedbackResponseDto>>(feedbacks);
        }

        public async Task<IEnumerable<FeedbackResponseDto>> GetFeedbacksByRatingAsync(int minRating, int maxRating, CancellationToken cancellationToken = default)
        {
            ValidateRating(minRating);
            ValidateRating(maxRating);

            var feedbacks = await _feedbackRepository.GetFeedbacksByRatingAsync(minRating, maxRating);
            return _mapper.Map<IEnumerable<FeedbackResponseDto>>(feedbacks);
        }

        public async Task<IEnumerable<FeedbackResponseDto>> GetFeedbacksByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            ValidateDateRange(startDate, endDate);

            var feedbacks = await _feedbackRepository.GetFeedbacksByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<FeedbackResponseDto>>(feedbacks);
        }

        public async Task<IEnumerable<FeedbackResponseDto>> GetFeedbacksByLanguageAsync(string languageCode, CancellationToken cancellationToken = default)
        {
            ValidateLanguageCode(languageCode);

            var feedbacks = await _feedbackRepository.GetFeedbacksByLanguageAsync(languageCode);
            return _mapper.Map<IEnumerable<FeedbackResponseDto>>(feedbacks);
        }

        public async Task<FeedbackResponseDto?> GetFeedbackByCorrelationIdAsync(Guid correlationId, CancellationToken cancellationToken = default)
        {
            var feedback = await _feedbackRepository.GetFeedbackByCorrelationIdAsync(correlationId);
            return feedback is null ? null : _mapper.Map<FeedbackResponseDto>(feedback);
        }

        public async Task<bool> UpdateFeedbackRatingAsync(Guid correlationId, int newRating, CancellationToken cancellationToken = default)
        {
            ValidateRating(newRating);

            var feedback = await _feedbackRepository.GetFeedbackByCorrelationIdAsync(correlationId);
            if (feedback is null)
            {
                _logger.LogWarning("Feedback with Correlation ID {CorrelationId} does not exist.", correlationId);
                throw new ArgumentException($"Feedback with Correlation ID {correlationId} does not exist.");
            }

            if (feedback.Rating == newRating)
            {
                _logger.LogInformation("Feedback with Correlation ID {CorrelationId} already has rating {Rating}.", correlationId, newRating);
                return false; // No update needed
            }

            return await _feedbackRepository.UpdateFeedbackRatingAsync(correlationId, newRating);
        }

        public async Task<bool> DeleteFeedbackByCorrelationIdAsync(Guid correlationId, CancellationToken cancellationToken = default)
        {
            var feedback = await _feedbackRepository.GetFeedbackByCorrelationIdAsync(correlationId);
            if (feedback is null)
            {
                _logger.LogWarning("Feedback with Correlation ID {CorrelationId} does not exist.", correlationId);
                throw new ArgumentException($"Feedback with Correlation ID {correlationId} does not exist.");
            }

            return await _feedbackRepository.DeleteFeedbackByCorrelationIdAsync(correlationId);
        }

        public async Task<IEnumerable<FeedbackResponseDto>> GetFeedbacksByUserId(long userId)
        {
            var feedback = await _feedbackRepository.GetFeedbacksByUserId(userId);
            if (feedback is null)
            {
                _logger.LogWarning("Feedback with userId ID {userId} does not exist.", userId);
                throw new ArgumentException($"Feedback with userId ID {userId} does not exist.");
            }

            return _mapper.Map<IEnumerable<FeedbackResponseDto>>(feedback);
        }
    }
}
