using AutoMapper;
using Core.Application.DTOs.Request.Language;
using Core.Application.DTOs.Response.Language;
using Core.Application.Interface.Language;
using Core.Application.Services;
using Domain.Core.Entities.Language;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Language;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Core.Application.Services.Language.Service
{
    public class LanguageService : GenericService<LanguagePackDto, LanguagePackResponseDto, long, LanguagePack>, ILanguageService
    {
        private readonly ILanguagePackRepository _languagePackRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<LanguageService> _logger;
        private static readonly Regex LanguageCodeRegex = new(@"^[a-zA-Z]{2,3}(-[a-zA-Z]{2,3})?$");

        public LanguageService(
            IMapper mapper,
            ILanguagePackRepository languagePackRepository,
            ILogger<LanguageService> logger,
            IGenericRepository<LanguagePack> repository,
            IAdditionalFeaturesRepository<LanguagePack> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _languagePackRepository = languagePackRepository;
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

        public async Task<IEnumerable<LanguagePackResponseDto>> GetAllActiveLanguages(CancellationToken cancellationToken = default)
        {
            var languages = await _languagePackRepository.GetAllActiveLanguages();
            return _mapper.Map<IEnumerable<LanguagePackResponseDto>>(languages);
        }

        public async Task<LanguagePackResponseDto?> GetLanguageByCode(string code, CancellationToken cancellationToken = default)
        {
            ValidateLanguageCode(code);

            var language = await _languagePackRepository.GetLanguageByCode(code);
            return language is null ? null : _mapper.Map<LanguagePackResponseDto>(language);
        }

        public async Task<bool> SoftDeleteLanguage(long languageId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(languageId, nameof(languageId));

            var language = await _languagePackRepository.GetByIdAsync(languageId, cancellationToken);
            if (language is null)
            {
                _logger.LogWarning("Language with ID {LanguageId} does not exist.", languageId);
                throw new ArgumentException($"Language with ID {languageId} does not exist.");
            }

            if (!language.IsActive)
            {
                _logger.LogWarning("Language with ID {LanguageId} is already deleted.", languageId);
                return false; // Already deleted
            }

            return await _languagePackRepository.SoftDeleteLanguage(languageId);
        }
    }
}
