using AutoMapper;
using Common.Data.Entities.Guest;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Guest;
using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.Interface.Guest;
using Core.Application.Services;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Core.Application.Services.Guest.Service
{
    public class GuestActiveLanguageService : GenericService<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage>, IGuestActiveLanguageService
    {
        private readonly IGuestActiveLanguageRepository _guestActiveLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GuestActiveLanguageService> _logger;
        private static readonly Regex LanguageCodeRegex = new(@"^[a-zA-Z]{2,3}(-[a-zA-Z]{2,3})?$");

        public GuestActiveLanguageService(
            IMapper mapper,
            IGuestActiveLanguageRepository guestActiveLanguageRepository,
            ILogger<GuestActiveLanguageService> logger,
            IGenericRepository<GuestActiveLanguage> repository,
            IAdditionalFeaturesRepository<GuestActiveLanguage> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _guestActiveLanguageRepository = guestActiveLanguageRepository;
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

        public async Task<GuestActiveLanguageResponseDto?> GetActiveLanguageByGuestIdAsync(long guestId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));

            var activeLanguage = await _guestActiveLanguageRepository.GetActiveLanguageByGuestIdAsync(guestId);
            return activeLanguage is null ? null : _mapper.Map<GuestActiveLanguageResponseDto>(activeLanguage);
        }

        public async Task<IEnumerable<GuestActiveLanguageResponseDto>> GetGuestLanguageHistoryAsync(long guestId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));

            var history = await _guestActiveLanguageRepository.GetGuestLanguageHistoryAsync(guestId);
            return _mapper.Map<IEnumerable<GuestActiveLanguageResponseDto>>(history);
        }

        public async Task<bool> SetGuestActiveLanguageAsync(long guestId, string languageCode, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));
            ValidateLanguageCode(languageCode);

            var currentActiveLanguage = await _guestActiveLanguageRepository.GetActiveLanguageByGuestIdAsync(guestId);
            if (currentActiveLanguage is not null && currentActiveLanguage.LanguageCode == languageCode)
            {
                _logger.LogInformation("Guest ID {GuestId} already has the active language set to {LanguageCode}.", guestId, languageCode);
                return false; // No update needed
            }

            return await _guestActiveLanguageRepository.SetGuestActiveLanguageAsync(guestId, languageCode);
        }

        public async Task<bool> RemoveGuestActiveLanguageAsync(long guestId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));

            var activeLanguage = await _guestActiveLanguageRepository.GetActiveLanguageByGuestIdAsync(guestId);
            if (activeLanguage is null)
            {
                _logger.LogWarning("No active language found for Guest ID {GuestId}.", guestId);
                return false;
            }

            return await _guestActiveLanguageRepository.RemoveGuestActiveLanguageAsync(guestId);
        }
    }
}
