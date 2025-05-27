using AutoMapper;
using Common.Data.Entities.Staff;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Staff;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.Category;
using Core.Application.Services;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.Category.Services
{
    public class StaffCategoryService : GenericService<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory>, IStaffCategoryService
    {
        private readonly IStaffCategoryRepository _staffCategoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<StaffCategoryService> _logger;

        public StaffCategoryService(
            IMapper mapper,
            IStaffCategoryRepository staffCategoryRepository,
            ILogger<StaffCategoryService> logger,
            IAdditionalFeaturesRepository<StaffCategory> additionalFeatures)
            : base(mapper, staffCategoryRepository, logger, additionalFeatures)
        {
            _staffCategoryRepository = staffCategoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        private void ValidateNotNull<T>(T value, string paramName)
        {
            if (value == null)
            {
                _logger.LogWarning("{ParameterName} cannot be null.", paramName);
                throw new ArgumentNullException(paramName, $"{paramName} cannot be null.");
            }
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

        public async Task<StaffCategoryResponseDto?> GetByCategoryNameAsync(string categoryName, CancellationToken cancellationToken = default)
        {
            ValidateString(categoryName, nameof(categoryName));

            var category = await _staffCategoryRepository.GetByCategoryNameAsync(categoryName, cancellationToken);
            return category is null ? null : _mapper.Map<StaffCategoryResponseDto>(category);
        }

        public async Task<IEnumerable<StaffCategoryResponseDto>> GetActiveCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _staffCategoryRepository.GetActiveCategoriesAsync(cancellationToken);
            return _mapper.Map<IEnumerable<StaffCategoryResponseDto>>(categories);
        }

        public async Task<IEnumerable<StaffCategoryResponseDto>> GetInactiveCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _staffCategoryRepository.GetInactiveCategoriesAsync(cancellationToken);
            return _mapper.Map<IEnumerable<StaffCategoryResponseDto>>(categories);
        }

        public async Task<IEnumerable<StaffCategoryResponseDto>> GetCategoriesCreatedBetweenDatesAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            if (startDate > endDate)
            {
                _logger.LogWarning("Start date cannot be after end date.");
                throw new ArgumentException("Start date cannot be after end date.");
            }

            var categories = await _staffCategoryRepository.GetCategoriesCreatedBetweenDatesAsync(startDate, endDate, cancellationToken);
            return _mapper.Map<IEnumerable<StaffCategoryResponseDto>>(categories);
        }

        public async Task<bool> UpdateCategoryNameAsync(long categoryId, string newName, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(categoryId, nameof(categoryId));
            ValidateString(newName, nameof(newName));

            return await _staffCategoryRepository.UpdateCategoryNameAsync(categoryId, newName, cancellationToken);
        }

        public async Task<bool> UpdateCategoryDescriptionAsync(long categoryId, string newDescription, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(categoryId, nameof(categoryId));
            ValidateString(newDescription, nameof(newDescription));

            return await _staffCategoryRepository.UpdateCategoryDescriptionAsync(categoryId, newDescription, cancellationToken);
        }

        public async Task<bool> IsCategoryAssignedToStaffAsync(long categoryId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(categoryId, nameof(categoryId));

            return await _staffCategoryRepository.IsCategoryAssignedToStaffAsync(categoryId, cancellationToken);
        }

        public async Task<IEnumerable<Staffs>> GetStaffByCategoryIdAsync(long categoryId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(categoryId, nameof(categoryId));

            return await _staffCategoryRepository.GetStaffByCategoryIdAsync(categoryId, cancellationToken);
        }

        public async Task<IEnumerable<TaskToStaff>> GetTasksByCategoryIdAsync(long categoryId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(categoryId, nameof(categoryId));

            return await _staffCategoryRepository.GetTasksByCategoryIdAsync(categoryId, cancellationToken);
        }
    }
}
