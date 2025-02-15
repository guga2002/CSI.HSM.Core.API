using AutoMapper;
using Core.Application.DTOs.Request.Audio;
using Core.Application.DTOs.Response.Audio;
using Core.Application.Interface.Audio;
using Core.Core.Entities.Audio;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Audio;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Audio.Service
{
    public class AudioResponseCategoryService : GenericService<AudioResponseCategoryRequestDto, AudioResponseCategoryResponseDto, long, AudioResponseCategory>, IAudioResponseCategoryService
    {
        private readonly IAudioResponseCategoryRepository _audioResponseCategoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AudioResponseCategoryService> _logger;

        public AudioResponseCategoryService(
            IMapper mapper,
            IAudioResponseCategoryRepository audioResponseCategoryRepository,
            ILogger<AudioResponseCategoryService> logger,
            IGenericRepository<AudioResponseCategory> repository,
            IAdditionalFeaturesRepository<AudioResponseCategory> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _audioResponseCategoryRepository = audioResponseCategoryRepository;
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

        private void ValidateCategoryName(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName) || categoryName.Length < 3)
            {
                _logger.LogWarning("Invalid category name: {CategoryName}", categoryName);
                throw new ArgumentException("Category name must be at least 3 characters long.");
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

        public async Task<AudioResponseCategoryResponseDto?> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken = default)
        {
            ValidateCategoryName(categoryName);

            var category = await _audioResponseCategoryRepository.GetCategoryByNameAsync(categoryName);
            return category is null ? null : _mapper.Map<AudioResponseCategoryResponseDto>(category);
        }

        public async Task<IEnumerable<AudioResponseCategoryResponseDto>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _audioResponseCategoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<IEnumerable<AudioResponseCategoryResponseDto>>(categories);
        }

        public async Task<bool> UpdateCategoryDescriptionAsync(long categoryId, string newDescription, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(categoryId, nameof(categoryId));
            ValidateDescription(newDescription);

            var category = await _audioResponseCategoryRepository.GetCategoryByNameAsync(categoryId.ToString());
            if (category is null)
            {
                _logger.LogWarning("Category with ID {CategoryId} does not exist.", categoryId);
                throw new ArgumentException($"Category with ID {categoryId} does not exist.");
            }

            if (category.Description == newDescription)
            {
                _logger.LogInformation("Category ID {CategoryId} already has the description set to {Description}.", categoryId, newDescription);
                return false; // No update needed
            }

            return await _audioResponseCategoryRepository.UpdateCategoryDescriptionAsync(categoryId, newDescription);
        }

        public async Task<bool> DeleteCategoryByIdAsync(long categoryId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(categoryId, nameof(categoryId));

            var category = await _audioResponseCategoryRepository.GetCategoryByNameAsync(categoryId.ToString());
            if (category is null)
            {
                _logger.LogWarning("Category with ID {CategoryId} does not exist.", categoryId);
                throw new ArgumentException($"Category with ID {categoryId} does not exist.");
            }

            return await _audioResponseCategoryRepository.DeleteCategoryByIdAsync(categoryId);
        }
    }
}
