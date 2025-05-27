using AutoMapper;
using Common.Data.Entities.Room;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Room;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.Room;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Room.Service
{
    public class RoomCategoryService : GenericService<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory>, IRoomCategoryService
    {
        private readonly IRoomCategoryRepository _roomCategoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RoomCategoryService> _logger;

        public RoomCategoryService(
            IMapper mapper,
            IRoomCategoryRepository roomCategoryRepository,
            ILogger<RoomCategoryService> logger,
            IAdditionalFeaturesRepository<RoomCategory> additionalFeatures)
            : base(mapper, roomCategoryRepository, logger, additionalFeatures)
        {
            _roomCategoryRepository = roomCategoryRepository;
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

        public async Task<RoomCategoryResponseDto?> GetCategoryByName(string categoryName, CancellationToken cancellationToken = default)
        {
            ValidateString(categoryName, nameof(categoryName));

            var category = await _roomCategoryRepository.GetCategoryByName(categoryName);
            return category is null ? null : _mapper.Map<RoomCategoryResponseDto>(category);
        }

        public async Task<IEnumerable<RoomCategoryResponseDto>> GetAllActiveCategories(CancellationToken cancellationToken = default)
        {
            var categories = await _roomCategoryRepository.GetAllActiveCategories();
            return _mapper.Map<IEnumerable<RoomCategoryResponseDto>>(categories);
        }

        public async Task<bool> UpdateRoomCategoryName(long categoryId, string newName, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(categoryId, nameof(categoryId));
            ValidateString(newName, nameof(newName));

            var category = await _roomCategoryRepository.GetByIdAsync(categoryId, cancellationToken);
            if (category is null)
            {
                _logger.LogWarning("Room category with ID {CategoryId} does not exist.", categoryId);
                throw new ArgumentException($"Room category with ID {categoryId} does not exist.");
            }

            return await _roomCategoryRepository.UpdateRoomCategoryName(categoryId, newName);
        }
    }
}
