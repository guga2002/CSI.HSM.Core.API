using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Domain.Core.Entities.Item;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Item;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Core.Application.Services.Item.Services
{
    public class ItemCategoryService : GenericService<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory>, IItemCategoryService
    {
        private readonly IItemCategoryRepository _itemCategoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ItemCategoryService> _logger;
        private static readonly Regex LanguageCodeRegex = new(@"^[a-zA-Z]{2,3}(-[a-zA-Z]{2,3})?$");

        public ItemCategoryService(
            IMapper mapper,
            IItemCategoryRepository itemCategoryRepository,
            ILogger<ItemCategoryService> logger,
            IGenericRepository<ItemCategory> repository,
            IAdditionalFeaturesRepository<ItemCategory> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _itemCategoryRepository = itemCategoryRepository;
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

        private void ValidateString(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _logger.LogWarning("{ParameterName} cannot be empty or whitespace.", paramName);
                throw new ArgumentException($"{paramName} cannot be empty or whitespace.", paramName);
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

        public async Task<ItemCategoryResponseDto?> GetCategoryByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            ValidateString(name, nameof(name));

            var category = await _itemCategoryRepository.GetCategoryByNameAsync(name, cancellationToken);
            return category is null ? null : _mapper.Map<ItemCategoryResponseDto>(category);
        }

        public async Task<IEnumerable<ItemCategoryResponseDto>> GetCategoriesByLanguageAsync(string languageCode, CancellationToken cancellationToken = default)
        {
            ValidateLanguageCode(languageCode);

            var categories = await _itemCategoryRepository.GetCategoriesByLanguageAsync(languageCode, cancellationToken);
            return _mapper.Map<IEnumerable<ItemCategoryResponseDto>>(categories);
        }

        public async Task<IEnumerable<ItemCategoryResponseDto>> GetCategoriesWithItemsAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _itemCategoryRepository.GetCategoriesWithItemsAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ItemCategoryResponseDto>>(categories);
        }

        public async Task<bool> UpdateCategoryNameAsync(long categoryId, string newName, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(categoryId, nameof(categoryId));
            ValidateString(newName, nameof(newName));

            var category = await _itemCategoryRepository.GetByIdAsync(categoryId, cancellationToken);
            if (category is null)
            {
                _logger.LogWarning("ItemCategory with ID {CategoryId} does not exist.", categoryId);
                throw new ArgumentException($"ItemCategory with ID {categoryId} does not exist.");
            }

            return await _itemCategoryRepository.UpdateCategoryNameAsync(categoryId, newName, cancellationToken);
        }

        public async Task<bool> UpdateCategoryDescriptionAsync(long categoryId, string newDescription, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(categoryId, nameof(categoryId));
            ValidateString(newDescription, nameof(newDescription));

            var category = await _itemCategoryRepository.GetByIdAsync(categoryId, cancellationToken);
            if (category is null)
            {
                _logger.LogWarning("ItemCategory with ID {CategoryId} does not exist.", categoryId);
                throw new ArgumentException($"ItemCategory with ID {categoryId} does not exist.");
            }

            return await _itemCategoryRepository.UpdateCategoryDescriptionAsync(categoryId, newDescription, cancellationToken);
        }

        public async Task<bool> ChangeCategoryLanguageAsync(long categoryId, string newLanguageCode, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(categoryId, nameof(categoryId));
            ValidateLanguageCode(newLanguageCode);

            var category = await _itemCategoryRepository.GetByIdAsync(categoryId, cancellationToken);
            if (category is null)
            {
                _logger.LogWarning("ItemCategory with ID {CategoryId} does not exist.", categoryId);
                throw new ArgumentException($"ItemCategory with ID {categoryId} does not exist.");
            }

            return await _itemCategoryRepository.ChangeCategoryLanguageAsync(categoryId, newLanguageCode, cancellationToken);
        }

        public async Task<int> CountTotalCategoriesAsync(CancellationToken cancellationToken = default)
        {
            return await _itemCategoryRepository.CountTotalCategoriesAsync(cancellationToken);
        }

        public async Task<int> CountCategoriesWithItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _itemCategoryRepository.CountCategoriesWithItemsAsync(cancellationToken);
        }
    }
}
