using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Core.Application.Services;
using Domain.Core.Entities.Item;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Item;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Item.Services
{
    public class ItemCategoryToStaffCategoryService :
        GenericService<ItemCategoryToStaffCategoryDto, ItemCategoryToStaffCategoryResponseDto, long, ItemCategoryToStaffCategory>,
        IItemCategoryToStaffCategoryService
    {
        private readonly IItemCategoryToStaffCategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ItemCategoryToStaffCategoryService> _logger;

        public ItemCategoryToStaffCategoryService(
            IMapper mapper,
            IItemCategoryToStaffCategoryRepository repository,
            ILogger<ItemCategoryToStaffCategoryService> logger,
            IGenericRepository<ItemCategoryToStaffCategory> genericRepository,
            IAdditionalFeaturesRepository<ItemCategoryToStaffCategory> additionalFeatures)
            : base(mapper, genericRepository, logger, additionalFeatures)
        {
            _repository = repository;
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

        public async Task<IEnumerable<ItemCategoryToStaffCategoryResponseDto>> GetByItemCategoryAsync(long itemCategoryId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(itemCategoryId, nameof(itemCategoryId));

            var mappings = await _repository.GetByItemCategoryAsync(itemCategoryId, cancellationToken);
            return _mapper.Map<IEnumerable<ItemCategoryToStaffCategoryResponseDto>>(mappings);
        }

        public async Task<IEnumerable<ItemCategoryToStaffCategoryResponseDto>> GetByStaffCategoryAsync(long staffCategoryId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffCategoryId, nameof(staffCategoryId));

            var mappings = await _repository.GetByStaffCategoryAsync(staffCategoryId, cancellationToken);
            return _mapper.Map<IEnumerable<ItemCategoryToStaffCategoryResponseDto>>(mappings);
        }

        public async Task<IEnumerable<ItemCategoryToStaffCategoryResponseDto>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default)
        {
            var mappings = await _repository.GetAllWithDetailsAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ItemCategoryToStaffCategoryResponseDto>>(mappings);
        }

        public async Task<bool> AddMappingAsync(long itemCategoryId, long staffCategoryId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(itemCategoryId, nameof(itemCategoryId));
            ValidatePositiveId(staffCategoryId, nameof(staffCategoryId));

            // Prevent duplicate mappings
            var existingMappings = await _repository.GetByItemCategoryAsync(itemCategoryId, cancellationToken);
            if (existingMappings.Any(m => m.StaffCategoryId == staffCategoryId))
            {
                _logger.LogWarning("Mapping between ItemCategory ID {ItemCategoryId} and StaffCategory ID {StaffCategoryId} already exists.", itemCategoryId, staffCategoryId);
                throw new InvalidOperationException($"Mapping between ItemCategory ID {itemCategoryId} and StaffCategory ID {staffCategoryId} already exists.");
            }

            return await _repository.AddMappingAsync(itemCategoryId, staffCategoryId, cancellationToken);
        }

        public async Task<bool> RemoveMappingAsync(long mappingId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(mappingId, nameof(mappingId));

            var mapping = await _repository.GetByIdAsync(mappingId, cancellationToken);
            if (mapping is null)
            {
                _logger.LogWarning("Mapping with ID {MappingId} does not exist.", mappingId);
                throw new ArgumentException($"Mapping with ID {mappingId} does not exist.");
            }

            return await _repository.RemoveMappingAsync(mappingId, cancellationToken);
        }

        public async Task<int> CountItemCategoriesMappedToStaffAsync(CancellationToken cancellationToken = default)
        {
            return await _repository.CountItemCategoriesMappedToStaffAsync(cancellationToken);
        }

        public async Task<int> CountStaffCategoriesMappedToItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _repository.CountStaffCategoriesMappedToItemsAsync(cancellationToken);
        }
    }
}
