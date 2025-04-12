using AutoMapper;
using Core.Application.DTOs.Request.Advertisment;
using Core.Application.Interface.Advertisment;
using Domain.Core.Entities.Advertisements;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Advertisement;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Core.Application.Services.Advertismenet.Service
{
    public class AdvertisementService : GenericService<AdvertismentDto, AdvertismentResponseDto, long, Advertisement>, IAdvertisementService
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AdvertisementService> _logger;
        private static readonly Regex LanguageCodeRegex = new(@"^[a-zA-Z]{2,3}(-[a-zA-Z]{2,3})?$");

        public AdvertisementService(
            IMapper mapper,
            IAdvertisementRepository advertisementRepository,
            ILogger<AdvertisementService> logger,
            IGenericRepository<Advertisement> repository,
            IAdditionalFeaturesRepository<Advertisement> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _advertisementRepository = advertisementRepository;
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

        public async Task<IEnumerable<AdvertismentResponseDto>> GetActiveAdvertisementsAsync(CancellationToken cancellationToken = default)
        {
            var advertisements = await _advertisementRepository.GetActiveAdvertisementsAsync();
            return _mapper.Map<IEnumerable<AdvertismentResponseDto>>(advertisements);
        }

        public async Task<IEnumerable<AdvertismentResponseDto>> GetAdvertisementsByTypeAsync(long advertisementTypeId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(advertisementTypeId, nameof(advertisementTypeId));

            var advertisements = await _advertisementRepository.GetAdvertisementsByTypeAsync(advertisementTypeId);
            return _mapper.Map<IEnumerable<AdvertismentResponseDto>>(advertisements);
        }

        public async Task<IEnumerable<AdvertismentResponseDto>> GetAdvertisementsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            ValidateDateRange(startDate, endDate);

            var advertisements = await _advertisementRepository.GetAdvertisementsByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<AdvertismentResponseDto>>(advertisements);
        }

        public async Task<IEnumerable<AdvertismentResponseDto>> GetAdvertisementsByLanguageAsync(string languageCode, CancellationToken cancellationToken = default)
        {
            ValidateLanguageCode(languageCode);

            var advertisements = await _advertisementRepository.GetAdvertisementsByLanguageAsync(languageCode);
            return _mapper.Map<IEnumerable<AdvertismentResponseDto>>(advertisements);
        }

        public async Task<AdvertismentResponseDto?> GetAdvertisementByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(title) || title.Length < 3)
            {
                _logger.LogWarning("Invalid advertisement title: {Title}", title);
                throw new ArgumentException("Advertisement title must be at least 3 characters long.");
            }

            var advertisement = await _advertisementRepository.GetAdvertisementByTitleAsync(title);
            return advertisement is null ? null : _mapper.Map<AdvertismentResponseDto>(advertisement);
        }

        public async Task<bool> UpdateAdvertisementDatesAsync(long id, DateTime? newStartDate, DateTime? newEndDate, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(id, nameof(id));

            if (newStartDate.HasValue && newEndDate.HasValue)
            {
                ValidateDateRange(newStartDate.Value, newEndDate.Value);
            }

            var advertisement = await _advertisementRepository.GetAdvertisementByTitleAsync(id.ToString());
            if (advertisement is null)
            {
                _logger.LogWarning("Advertisement with ID {Id} does not exist.", id);
                throw new ArgumentException($"Advertisement with ID {id} does not exist.");
            }

            if (advertisement.StartDate == newStartDate && advertisement.EndDate == newEndDate)
            {
                _logger.LogInformation("No changes detected in advertisement ID {Id} start/end dates.", id);
                return false; // No update required
            }

            return await _advertisementRepository.UpdateAdvertisementDatesAsync(id, newStartDate, newEndDate);
        }

        public async Task<bool> DeleteAdvertisementByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(id, nameof(id));
            return await _advertisementRepository.DeleteAdvertisementByIdAsync(id);
        }
    }
}
