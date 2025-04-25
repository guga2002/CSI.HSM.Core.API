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
    public class TaskItemService : GenericService<TaskItemDto, TaskItemResponseDto, long, TaskItem>, ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TaskItemService> _logger;

        public TaskItemService(
            IMapper mapper,
            ITaskItemRepository taskItemRepository,
            ILogger<TaskItemService> logger,
            IGenericRepository<TaskItem> repository,
            IAdditionalFeaturesRepository<TaskItem> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _taskItemRepository = taskItemRepository;
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

        private void ValidateQuantity(int quantity)
        {
            if (quantity < 0)
            {
                _logger.LogWarning("Quantity must be non-negative.");
                throw new ArgumentException("Quantity must be a non-negative value.");
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

        public async Task<IEnumerable<TaskItemResponseDto>> GetTaskItemsByTaskIdAsync(long taskId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(taskId, nameof(taskId));

            var items = await _taskItemRepository.GetTaskItemsByTaskIdAsync(taskId, cancellationToken);
            return _mapper.Map<IEnumerable<TaskItemResponseDto>>(items);
        }

        public async Task<IEnumerable<TaskItemResponseDto>> GetTaskItemsByItemIdAsync(long itemId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(itemId, nameof(itemId));

            var items = await _taskItemRepository.GetTaskItemsByItemIdAsync(itemId, cancellationToken);
            return _mapper.Map<IEnumerable<TaskItemResponseDto>>(items);
        }

        public async Task<IEnumerable<TaskItemResponseDto>> GetPendingTaskItemsAsync(CancellationToken cancellationToken = default)
        {
            var items = await _taskItemRepository.GetPendingTaskItemsAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TaskItemResponseDto>>(items);
        }

        public async Task<IEnumerable<TaskItemResponseDto>> GetCompletedTaskItemsAsync(CancellationToken cancellationToken = default)
        {
            var items = await _taskItemRepository.GetCompletedTaskItemsAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TaskItemResponseDto>>(items);
        }

        public async Task<bool> UpdateItemQuantityAsync(long taskItemId, int newQuantity, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(taskItemId, nameof(taskItemId));
            ValidateQuantity(newQuantity);

            var taskItem = await _taskItemRepository.GetByIdAsync(taskItemId, cancellationToken);
            if (taskItem is null)
            {
                _logger.LogWarning("TaskItem with ID {TaskItemId} does not exist.", taskItemId);
                throw new ArgumentException($"TaskItem with ID {taskItemId} does not exist.");
            }

            return await _taskItemRepository.UpdateItemQuantityAsync(taskItemId, newQuantity, cancellationToken);
        }

        public async Task<bool> MarkTaskItemCompletedAsync(long taskItemId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(taskItemId, nameof(taskItemId));

            var taskItem = await _taskItemRepository.GetByIdAsync(taskItemId, cancellationToken);
            if (taskItem is null)
            {
                _logger.LogWarning("TaskItem with ID {TaskItemId} does not exist.", taskItemId);
                throw new ArgumentException($"TaskItem with ID {taskItemId} does not exist.");
            }

            return await _taskItemRepository.MarkTaskItemCompletedAsync(taskItemId, cancellationToken);
        }

        public async Task<bool> AddNotesToTaskItemAsync(long taskItemId, string notes, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(taskItemId, nameof(taskItemId));
            ValidateString(notes, nameof(notes));

            var taskItem = await _taskItemRepository.GetByIdAsync(taskItemId, cancellationToken);
            if (taskItem is null)
            {
                _logger.LogWarning("TaskItem with ID {TaskItemId} does not exist.", taskItemId);
                throw new ArgumentException($"TaskItem with ID {taskItemId} does not exist.");
            }

            return await _taskItemRepository.AddNotesToTaskItemAsync(taskItemId, notes, cancellationToken);
        }

        public async Task<int> CountTotalItemsInTaskAsync(long taskId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(taskId, nameof(taskId));

            return await _taskItemRepository.CountTotalItemsInTaskAsync(taskId, cancellationToken);
        }

        public async Task<int> CountCompletedItemsInTaskAsync(long taskId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(taskId, nameof(taskId));

            return await _taskItemRepository.CountCompletedItemsInTaskAsync(taskId, cancellationToken);
        }
    }
}
