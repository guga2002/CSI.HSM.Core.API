using AutoMapper;
using Core.Application.CustomExceptions;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.Task;
using Domain.Core.Entities.Staff;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Staff;
using Domain.Core.Sheared;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.Cart.Services
{
    public class TaskToStaffService : GenericService<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>, ITaskToStaffService
    {
        private readonly ITaskToStaffRepository _taskToStaffRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TaskToStaffService> _logger;

        public TaskToStaffService(
            IMapper mapper,
            ITaskToStaffRepository taskToStaffRepository,
            ILogger<TaskToStaffService> logger,
            IAdditionalFeaturesRepository<TaskToStaff> additionalFeatures)
            : base(mapper, taskToStaffRepository, logger, additionalFeatures)
        {
            _taskToStaffRepository = taskToStaffRepository;
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

        public async Task<TaskToStaffResponseDto?> GetByTaskIdAsync(long taskId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(taskId, nameof(taskId));

            var task = await _taskToStaffRepository.GetByTaskIdAsync(taskId, cancellationToken);
            return task is null ? null : _mapper.Map<TaskToStaffResponseDto>(task);
        }

        public async Task<IEnumerable<GroupTasksStatusByCard>> GetTasksStatusByCardAsync(long cardId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(cardId, nameof(cardId));

            return await _taskToStaffRepository.GetTasksStatusByCardAsync(cardId, cancellationToken);
        }

        public async Task<IEnumerable<TaskToStaffResponseDto>> GetTasksByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            var tasks = await _taskToStaffRepository.GetTasksByStaffIdAsync(staffId, cancellationToken);
            return _mapper.Map<IEnumerable<TaskToStaffResponseDto>>(tasks);
        }

        public async Task<bool> UpdateTaskStatusAsync(long taskId, long statusId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(taskId, nameof(taskId));
            ValidatePositiveId(statusId, nameof(statusId));

            return await _taskToStaffRepository.UpdateTaskStatusAsync(taskId, statusId, cancellationToken);
        }

        public async Task<bool> MarkTaskAsCompletedAsync(long taskId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(taskId, nameof(taskId));

            return await _taskToStaffRepository.MarkTaskAsCompletedAsync(taskId, cancellationToken);
        }

        public async Task<bool> AssignTaskToStaffAsync(long taskId, long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(taskId, nameof(taskId));
            ValidatePositiveId(staffId, nameof(staffId));

            var existingTask = await _taskToStaffRepository.GetByTaskIdAsync(taskId, cancellationToken);
            if (existingTask is not null)
            {
                _logger.LogWarning("Task {TaskId} has already been completed and cannot be reassigned.", taskId);
                throw new BusinessRuleViolationException($"Task {taskId} has already been completed and cannot be reassigned.");
            }

            return await _taskToStaffRepository.AssignTaskToStaffAsync(taskId, staffId, cancellationToken);
        }

        public async Task<IEnumerable<TaskToStaffResponseDto>> GetActiveTasksByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            var tasks = await _taskToStaffRepository.GetActiveTasksByStaffIdAsync(staffId, cancellationToken);
            return _mapper.Map<IEnumerable<TaskToStaffResponseDto>>(tasks);
        }

        public async Task<IEnumerable<TaskToStaffResponseDto>> GetDueTasksAsync(DateTime dueDate, CancellationToken cancellationToken = default)
        {
            if (dueDate < DateTime.UtcNow)
            {
                _logger.LogWarning("Due date cannot be in the past.");
                throw new ArgumentException("Due date cannot be in the past.");
            }

            var tasks = await _taskToStaffRepository.GetDueTasksAsync(dueDate, cancellationToken);
            return _mapper.Map<IEnumerable<TaskToStaffResponseDto>>(tasks);
        }
    }
}
