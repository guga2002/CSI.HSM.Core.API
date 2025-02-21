using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Item;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Core.Application.Services.Item.Services
{
    public class ItemService : GenericService<ItemDto, ItemResponseDto, long, Items>, IItemService
    {
        private readonly IItemsRepository _itemsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ItemService> _logger;
        private static readonly Regex LanguageCodeRegex = new(@"^[a-zA-Z]{2,3}(-[a-zA-Z]{2,3})?$");

        public ItemService(
            IMapper mapper,
            IItemsRepository itemsRepository,
            ILogger<ItemService> logger,
            IGenericRepository<Items> repository,
            IAdditionalFeaturesRepository<Items> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _itemsRepository = itemsRepository;
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

        private void ValidateQuantity(int quantity)
        {
            if (quantity < 0)
            {
                _logger.LogWarning("Quantity must be non-negative.");
                throw new ArgumentException("Quantity must be a non-negative value.");
            }
        }

        private void ValidatePrice(decimal price)
        {
            if (price <= 0)
            {
                _logger.LogWarning("Price must be greater than zero.");
                throw new ArgumentException("Price must be greater than zero.");
            }
        }

        public async Task<IEnumerable<ItemResponseDto>> GetItemsByCategoryAsync(long categoryId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(categoryId, nameof(categoryId));

            var items = await _itemsRepository.GetItemsByCategoryAsync(categoryId, cancellationToken);
            return _mapper.Map<IEnumerable<ItemResponseDto>>(items);
        }

        public async Task<IEnumerable<ItemResponseDto>> GetItemsByLanguageAsync(string languageCode, CancellationToken cancellationToken = default)
        {
            ValidateLanguageCode(languageCode);

            var items = await _itemsRepository.GetItemsByLanguageAsync(languageCode, cancellationToken);
            return _mapper.Map<IEnumerable<ItemResponseDto>>(items);
        }

        public async Task<IEnumerable<ItemResponseDto>> GetOrderableItemsAsync(CancellationToken cancellationToken = default)
        {
            var items = await _itemsRepository.GetOrderableItemsAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ItemResponseDto>>(items);
        }

        //public async Task<IEnumerable<ItemResponseDto>> GetOutOfStockItemsAsync(CancellationToken cancellationToken = default)
        //{
        //    var items = await _itemsRepository.GetOutOfStockItemsAsync(cancellationToken);
        //    return _mapper.Map<IEnumerable<ItemResponseDto>>(items);
        //}

        //public async Task<bool> UpdateItemQuantityAsync(long itemId, int newQuantity, CancellationToken cancellationToken = default)
        //{
        //    ValidatePositiveId(itemId, nameof(itemId));
        //    ValidateQuantity(newQuantity);

        //    var item = await _itemsRepository.GetByIdAsync(itemId, cancellationToken);
        //    if (item is null)
        //    {
        //        _logger.LogWarning("Item with ID {ItemId} does not exist.", itemId);
        //        throw new ArgumentException($"Item with ID {itemId} does not exist.");
        //    }

        //    return await _itemsRepository.UpdateItemQuantityAsync(itemId, newQuantity, cancellationToken);
        //}

        public async Task<bool> UpdateItemPriceAsync(long itemId, decimal newPrice, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(itemId, nameof(itemId));
            ValidatePrice(newPrice);

            var item = await _itemsRepository.GetByIdAsync(itemId, cancellationToken);
            if (item is null)
            {
                _logger.LogWarning("Item with ID {ItemId} does not exist.", itemId);
                throw new ArgumentException($"Item with ID {itemId} does not exist.");
            }

            return await _itemsRepository.UpdateItemPriceAsync(itemId, newPrice, cancellationToken);
        }

        public async Task<bool> SetItemOrderableStatusAsync(long itemId, bool isOrderable, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(itemId, nameof(itemId));

            var item = await _itemsRepository.GetByIdAsync(itemId, cancellationToken);
            if (item is null)
            {
                _logger.LogWarning("Item with ID {ItemId} does not exist.", itemId);
                throw new ArgumentException($"Item with ID {itemId} does not exist.");
            }

            return await _itemsRepository.SetItemOrderableStatusAsync(itemId, isOrderable, cancellationToken);
        }

        public async Task<int> CountItemsInCategoryAsync(long categoryId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(categoryId, nameof(categoryId));

            return await _itemsRepository.CountItemsInCategoryAsync(categoryId, cancellationToken);
        }

        public async Task<int> CountOrderableItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _itemsRepository.CountOrderableItemsAsync(cancellationToken);
        }
    }
}
