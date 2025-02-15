using AutoMapper;
using Microsoft.Extensions.Logging;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.Task.Task;
using Core.Core.Entities.Task;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Task;

namespace Core.Application.Services.Task.Task.Services
{
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

        public async Task<bool> UpdateTaskStatus(long taskId, Core.Entities.Task.TaskStatus newStatus)
        {
            return await _taskRepository.UpdateTaskStatus(taskId, newStatus);
        }

        public async Task<IEnumerable<TaskResponseDto>> GetTasksByStatus(Core.Entities.Task.TaskStatus status, int limit = 50)
        {
            var tasks = await _taskRepository.GetTasksByStatus(status, limit);
            return _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
        }

        public async Task<IEnumerable<TaskResponseDto>> GetHighPriorityTasks(int limit = 10)
        {
            var tasks = await _taskRepository.GetHighPriorityTasks(limit);
            return _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
        }
    }
}
