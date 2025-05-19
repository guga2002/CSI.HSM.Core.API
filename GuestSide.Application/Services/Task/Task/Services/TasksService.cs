using AutoMapper;
using Microsoft.Extensions.Logging;
using Domain.Core.Entities.Task;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Task;
using Domain.Core.Entities.Item;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.Task.Task;
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

    public async Task<bool> UpdateTaskPriority(long taskId, long priorityId)
    {
        return await _taskRepository.UpdateTaskPriority(taskId, priorityId);
    }

    public async Task<Dictionary<long, IEnumerable<TaskItem>>> GetTaskItemsByCartIdAsync(long cartId)
    {
        var tasks = await _taskRepository.GetTaskItemsByCartIdAsync(cartId);
        return tasks;
    }

    public async Task<IEnumerable<TaskResponseDto>> GetFilteredTasks(FilterTaskDto filterTaskDto)
    {
        var tasks = await _taskRepository.GetFilteredTasks
           (filterTaskDto.PriorityId,
            filterTaskDto.IsCompleted,
            filterTaskDto.StartDate,
            filterTaskDto.EndDate);

        return _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
    }
}
