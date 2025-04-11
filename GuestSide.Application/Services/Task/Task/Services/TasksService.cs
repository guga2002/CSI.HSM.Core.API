using AutoMapper;
using Microsoft.Extensions.Logging;
using Domain.Core.Entities.Task;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Task;
using Domain.Core.Entities.Item;
using Domain.Core.Entities.Enums;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.Task.Task;
using Core.Application.Services;
using Core.Application.DTOs.Request.Task;

namespace Core.Application.Services.Task.Task.Services;

public class TasksService : GenericService<TaskDto, TaskResponseDto, long, Tasks>, ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public TasksService(
        IMapper mapper,
        ITaskRepository taskRepository,
        ILogger<GenericService<TaskDto, TaskResponseDto, long, Tasks>> logger,
        IAdditionalFeaturesRepository<Tasks> additionalFeatures)
        : base(mapper, taskRepository, logger, additionalFeatures)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TaskResponseDto>> GetTasksByCartId(long cartId, CancellationToken cancellationToken = default)
    {
        var tasks = await _taskRepository.GetTasksByCartId(cartId);
        return _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
    }

    public async Task<bool> UpdateTaskStatus(long taskId, StatusEnum newStatus)
    {
        return await _taskRepository.UpdateTaskStatus(taskId, newStatus);
    }

    public async Task<bool> UpdateTaskPriority(long taskId, PriorityEnum newPriority)
    {
        return await _taskRepository.UpdateTaskPriority(taskId, newPriority);
    }

    public async Task<IEnumerable<TaskResponseDto>> GetTasksByStatus(StatusEnum status, int limit = 50)
    {
        var tasks = await _taskRepository.GetTasksByStatus(status, limit);
        return _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
    }

    public async Task<IEnumerable<TaskResponseDto>> GetHighPriorityTasks(int limit = 10)
    {
        var tasks = await _taskRepository.GetHighPriorityTasks(limit);
        return _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
    }

    public async Task<Dictionary<long, IEnumerable<TaskItem>>> GetTaskItemsByCartIdAsync(long cartId)
    {
        var tasks = await _taskRepository.GetTaskItemsByCartIdAsync(cartId);
        return tasks;
    }

    public async Task<IEnumerable<TaskResponseDto>> GetFilteredTasks(FilterTaskDto filterTaskDto)
    {
        var tasks = await _taskRepository.GetFilteredTasks
           (filterTaskDto.Status,
            filterTaskDto.Priority,
            filterTaskDto.IsCompleted,
            filterTaskDto.StartDate,
            filterTaskDto.EndDate);

        return _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
    }
}
