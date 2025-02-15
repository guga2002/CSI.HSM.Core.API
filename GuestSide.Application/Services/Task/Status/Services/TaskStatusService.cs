using AutoMapper;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.Task.Status;
using Core.Core.Entities.Task;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Task;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Task.Status.Services
{
    public class TaskStatusService : GenericService<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus>, ITaskStatusService
    {
        private readonly ITaskStatusRepository _taskStatusRepository;
        private readonly IMapper _mapper;

        public TaskStatusService(
            IMapper mapper,
            ITaskStatusRepository taskStatusRepository,
            ILogger<GenericService<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus>> logger,
            IAdditionalFeaturesRepository<TasksStatus> additionalFeatures)
            : base(mapper, taskStatusRepository, logger, additionalFeatures) 
        {
            _taskStatusRepository = taskStatusRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskStatusResponseDto>> GetAllTaskStatusesAsync(CancellationToken cancellationToken = default)
        {
            var statuses = await _taskStatusRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TaskStatusResponseDto>>(statuses);
        }

        public async Task<TaskStatusResponseDto?> GetTaskStatusByNameAsync(string statusName, CancellationToken cancellationToken = default)
        {
            var status = await _taskStatusRepository.GetStatusByName(statusName);
            return status is null ? null : _mapper.Map<TaskStatusResponseDto>(status);
        }

        public async Task<bool> UpdateTaskStatusNameAsync(long statusId, string newName, CancellationToken cancellationToken = default)
        {
            return await _taskStatusRepository.UpdateTaskStatusName(statusId, newName);
        }

        public async Task<IEnumerable<TaskStatusResponseDto>> GetAllActiveStatusesAsync(CancellationToken cancellationToken = default)
        {
            var activeStatuses = await _taskStatusRepository.GetAllActiveStatuses();
            return _mapper.Map<IEnumerable<TaskStatusResponseDto>>(activeStatuses);
        }
    }
}
