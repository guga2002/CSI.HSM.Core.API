using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.Sentiments;
using Core.Application.Services;
using Domain.Core.Entities.Staff;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Staff;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.Sentiments.Service
{
    public class StaffSentimentService : GenericService<StaffSentimentDto, StaffSentimentResponseDto, long, StaffSentiment>, IStaffSentimentService
    {
        private readonly IStaffSentimentRepository _staffSentimentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<StaffSentimentService> _logger;

        public StaffSentimentService(
            IMapper mapper,
            IStaffSentimentRepository staffSentimentRepository,
            ILogger<StaffSentimentService> logger,
            IGenericRepository<StaffSentiment> repository,
            IAdditionalFeaturesRepository<StaffSentiment> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _staffSentimentRepository = staffSentimentRepository;
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

        private void ValidateStringInput(string input, string paramName)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 3)
            {
                _logger.LogWarning("{ParameterName} must be at least 3 characters long.", paramName);
                throw new ArgumentException($"{paramName} must be at least 3 characters long.");
            }
        }

        public async Task<IEnumerable<StaffSentimentResponseDto>> GetSentimentsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            var sentiments = await _staffSentimentRepository.GetSentimentsByStaffIdAsync(staffId, cancellationToken);
            return _mapper.Map<IEnumerable<StaffSentimentResponseDto>>(sentiments);
        }

        public async Task<IEnumerable<StaffSentimentResponseDto>> GetSentimentsByLabelAsync(string label, CancellationToken cancellationToken = default)
        {
            ValidateStringInput(label, nameof(label));

            var sentiments = await _staffSentimentRepository.GetSentimentsByLabelAsync(label, cancellationToken);
            return _mapper.Map<IEnumerable<StaffSentimentResponseDto>>(sentiments);
        }

        public async Task<IEnumerable<StaffSentimentResponseDto>> GetSentimentsByEmotionAsync(string emotion, CancellationToken cancellationToken = default)
        {
            ValidateStringInput(emotion, nameof(emotion));

            var sentiments = await _staffSentimentRepository.GetSentimentsByEmotionAsync(emotion, cancellationToken);
            return _mapper.Map<IEnumerable<StaffSentimentResponseDto>>(sentiments);
        }

        public async Task<IEnumerable<StaffSentimentResponseDto>> GetRecentSentimentsAsync(int days, CancellationToken cancellationToken = default)
        {
            if (days <= 0)
            {
                _logger.LogWarning("Days must be a positive number.");
                throw new ArgumentException("Days must be greater than zero.");
            }

            var sentiments = await _staffSentimentRepository.GetRecentSentimentsAsync(days, cancellationToken);
            return _mapper.Map<IEnumerable<StaffSentimentResponseDto>>(sentiments);
        }

        public async Task<bool> UpdateSentimentLabelAsync(long sentimentId, string newLabel, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(sentimentId, nameof(sentimentId));
            ValidateStringInput(newLabel, nameof(newLabel));

            var sentiment = await _staffSentimentRepository.GetSentimentsByStaffIdAsync(sentimentId, cancellationToken);
            if (sentiment is null)
            {
                _logger.LogWarning("Sentiment with ID {Id} does not exist.", sentimentId);
                throw new ArgumentException($"Sentiment with ID {sentimentId} does not exist.");
            }

            return await _staffSentimentRepository.UpdateSentimentLabelAsync(sentimentId, newLabel, cancellationToken);
        }

        public async Task<bool> UpdateSentimentConfidenceAsync(long sentimentId, double newConfidence, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(sentimentId, nameof(sentimentId));

            if (newConfidence < 0 || newConfidence > 1)
            {
                _logger.LogWarning("Confidence value must be between 0 and 1.");
                throw new ArgumentException("Confidence value must be between 0 and 1.");
            }

            return await _staffSentimentRepository.UpdateSentimentConfidenceAsync(sentimentId, newConfidence, cancellationToken);
        }

        public async Task<double?> GetAverageSentimentScoreAsync(long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            return await _staffSentimentRepository.GetAverageSentimentScoreAsync(staffId, cancellationToken);
        }

        public async Task<IEnumerable<long>> GetNegativeSentimentStaffAsync(double threshold, CancellationToken cancellationToken = default)
        {
            if (threshold < 0 || threshold > 1)
            {
                _logger.LogWarning("Threshold must be between 0 and 1.");
                throw new ArgumentException("Threshold must be between 0 and 1.");
            }

            return await _staffSentimentRepository.GetNegativeSentimentStaffAsync(threshold, cancellationToken);
        }
    }
}
