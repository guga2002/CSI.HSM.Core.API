using AutoMapper;
using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;
using Core.Application.Interface.AdvertiementType;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Advertisement;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Core.Application.Services.AdvertisementType
{
    public class AdvertisementTypeService : GenericService<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, Core.Entities.Advertisements.AdvertisementType>, IAdvertisementTypeService
    {
        private readonly IAdvertisementTypeRepository _advertisementTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AdvertisementTypeService> _logger;
        private static readonly Regex LanguageCodeRegex = new(@"^[a-zA-Z]{2,3}(-[a-zA-Z]{2,3})?$");

        public AdvertisementTypeService(
            IMapper mapper,
            IAdvertisementTypeRepository advertisementTypeRepository,
            ILogger<AdvertisementTypeService> logger,
            IGenericRepository<Core.Entities.Advertisements.AdvertisementType> repository,
            IAdditionalFeaturesRepository<Core.Entities.Advertisements.AdvertisementType> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _advertisementTypeRepository = advertisementTypeRepository;
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

        private void ValidateTypeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                _logger.LogWarning("Invalid advertisement type name: {TypeName}", name);
                throw new ArgumentException("Advertisement type name must be at least 3 characters long.");
            }
        }

        private void ValidateDescription(string description)
        {
            if (!string.IsNullOrWhiteSpace(description) && description.Length < 5)
            {
                _logger.LogWarning("Invalid description: {Description}", description);
                throw new ArgumentException("Description must be at least 5 characters long.");
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

        public async Task<AdvertisementTypeResponseDto?> GetAdvertisementTypeByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            ValidateTypeName(name);

            var advertisementType = await _advertisementTypeRepository.GetAdvertisementTypeByNameAsync(name);
            return advertisementType is null ? null : _mapper.Map<AdvertisementTypeResponseDto>(advertisementType);
        }

        public async Task<IEnumerable<AdvertisementTypeResponseDto>> GetAllAdvertisementTypesAsync(CancellationToken cancellationToken = default)
        {
            var advertisementTypes = await _advertisementTypeRepository.GetAllAdvertisementTypesAsync();
            return _mapper.Map<IEnumerable<AdvertisementTypeResponseDto>>(advertisementTypes);
        }

        public async Task<IEnumerable<AdvertisementTypeResponseDto>> GetAdvertisementTypesByLanguageAsync(string languageCode, CancellationToken cancellationToken = default)
        {
            ValidateLanguageCode(languageCode);

            var advertisementTypes = await _advertisementTypeRepository.GetAdvertisementTypesByLanguageAsync(languageCode);
            return _mapper.Map<IEnumerable<AdvertisementTypeResponseDto>>(advertisementTypes);
        }

        public async Task<bool> UpdateAdvertisementTypeDescriptionAsync(long advertisementTypeId, string newDescription, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(advertisementTypeId, nameof(advertisementTypeId));
            ValidateDescription(newDescription);

            var advertisementType = await _advertisementTypeRepository.GetAdvertisementTypeByNameAsync(advertisementTypeId.ToString());
            if (advertisementType is null)
            {
                _logger.LogWarning("AdvertisementType with ID {Id} does not exist.", advertisementTypeId);
                throw new ArgumentException($"AdvertisementType with ID {advertisementTypeId} does not exist.");
            }

            if (advertisementType.Description == newDescription)
            {
                _logger.LogInformation("AdvertisementType ID {Id} already has the description set to {Description}.", advertisementTypeId, newDescription);
                return false; // No update needed
            }

            return await _advertisementTypeRepository.UpdateAdvertisementTypeDescriptionAsync(advertisementTypeId, newDescription);
        }

        public async Task<bool> DeleteAdvertisementTypeByIdAsync(long advertisementTypeId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(advertisementTypeId, nameof(advertisementTypeId));

            var advertisementType = await _advertisementTypeRepository.GetAdvertisementTypeByNameAsync(advertisementTypeId.ToString());
            if (advertisementType is null)
            {
                _logger.LogWarning("AdvertisementType with ID {Id} does not exist.", advertisementTypeId);
                throw new ArgumentException($"AdvertisementType with ID {advertisementTypeId} does not exist.");
            }

            return await _advertisementTypeRepository.DeleteAdvertisementTypeByIdAsync(advertisementTypeId);
        }
    }
}
