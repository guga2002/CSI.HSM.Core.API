using AutoMapper;
using Core.Application.DTOs.Request.Audio;
using Core.Application.DTOs.Response.Audio;
using Core.Application.Interface.Audio;
using Core.Core.Entities.Audio;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Audio;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Core.Application.Services.Audio.Service
{
    public class AudioResponseService : GenericService<AudioRequestDto, AudioResponseDto, long, AudioResponse>, IAudioResponseService
    {
        private readonly IAudioResponseRepository _audioResponseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AudioResponseService> _logger;
        private static readonly Regex LanguageCodeRegex = new(@"^[a-zA-Z]{2,3}(-[a-zA-Z]{2,3})?$");

        public AudioResponseService(
            IMapper mapper,
            IAudioResponseRepository audioResponseRepository,
            ILogger<AudioResponseService> logger,
            IGenericRepository<AudioResponse> repository,
            IAdditionalFeaturesRepository<AudioResponse> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _audioResponseRepository = audioResponseRepository;
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

        private void ValidateLanguageCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code) || !LanguageCodeRegex.IsMatch(code))
            {
                _logger.LogWarning("Invalid language code format: {Code}", code);
                throw new ArgumentException("Invalid language code format. Expected format: 'en', 'fr', 'es', or 'en-US'.");
            }
        }

        private void ValidateString(string? value, string paramName)
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Length < 3)
            {
                _logger.LogWarning("{ParameterName} must be at least 3 characters long.", paramName);
                throw new ArgumentException($"{paramName} must be at least 3 characters long.");
            }
        }

        public async Task<IEnumerable<AudioResponseDto>> GetAudioResponsesByLanguageAsync(string languageCode, CancellationToken cancellationToken = default)
        {
            ValidateLanguageCode(languageCode);

            var audioResponses = await _audioResponseRepository.GetAudioResponsesByLanguageAsync(languageCode);
            return _mapper.Map<IEnumerable<AudioResponseDto>>(audioResponses);
        }

        public async Task<IEnumerable<AudioResponseDto>> GetAudioResponsesByVoiceTypeAsync(string voiceType, CancellationToken cancellationToken = default)
        {
            ValidateString(voiceType, nameof(voiceType));

            var audioResponses = await _audioResponseRepository.GetAudioResponsesByVoiceTypeAsync(voiceType);
            return _mapper.Map<IEnumerable<AudioResponseDto>>(audioResponses);
        }

        public async Task<IEnumerable<AudioResponseDto>> GetAudioResponsesByCategoryAsync(long categoryId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(categoryId, nameof(categoryId));

            var audioResponses = await _audioResponseRepository.GetAudioResponsesByCategoryAsync(categoryId);
            return _mapper.Map<IEnumerable<AudioResponseDto>>(audioResponses);
        }

        public async Task<IEnumerable<AudioResponseDto>> GetAudioResponsesByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            if (startDate > endDate)
            {
                _logger.LogWarning("Invalid date range: {StartDate} - {EndDate}", startDate, endDate);
                throw new ArgumentException("Start date must be before or equal to the end date.");
            }

            var audioResponses = await _audioResponseRepository.GetAudioResponsesByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<AudioResponseDto>>(audioResponses);
        }

        public async Task<AudioResponseDto?> GetAudioResponseByTextContentAsync(string textContent, CancellationToken cancellationToken = default)
        {
            ValidateString(textContent, nameof(textContent));

            var audioResponse = await _audioResponseRepository.GetAudioResponseByTextContentAsync(textContent);
            return audioResponse is null ? null : _mapper.Map<AudioResponseDto>(audioResponse);
        }

        public async Task<bool> UpdateAudioResponsePathAsync(long id, string newAudioFilePath, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(id, nameof(id));
            ValidateString(newAudioFilePath, nameof(newAudioFilePath));

            var audioResponse = await _audioResponseRepository.GetAudioResponseByTextContentAsync(newAudioFilePath);
            if (audioResponse is not null && audioResponse.AudioFilePath == newAudioFilePath)
            {
                _logger.LogInformation("AudioResponse ID {Id} already has the file path set to {Path}.", id, newAudioFilePath);
                return false; // No update needed
            }

            return await _audioResponseRepository.UpdateAudioResponsePathAsync(id, newAudioFilePath);
        }

        public async Task<bool> DeleteAudioResponseByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(id, nameof(id));

            var audioResponse = await _audioResponseRepository.GetAudioResponseByTextContentAsync(id.ToString());
            if (audioResponse is null)
            {
                _logger.LogWarning("AudioResponse with ID {Id} does not exist.", id);
                throw new ArgumentException($"AudioResponse with ID {id} does not exist.");
            }

            return await _audioResponseRepository.DeleteAudioResponseByIdAsync(id);
        }
    }
}
