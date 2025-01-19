using AutoMapper;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Application.Interface.Task.Task;
using GuestSide.Application.Services;
using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Task;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Task.Task.Services
{
    public class TasksService : GenericService<TaskDto, TaskResponseDto, long, Tasks>, ITaskService
    {
        private readonly ITaskRepository tasks;
        private readonly IMapper map;
        public TasksService(ITaskRepository tasks, IMapper mapper, IGenericRepository<Tasks> repository, ILogger<GenericService<TaskDto, TaskResponseDto, long, Tasks>> logger) : base(mapper, repository, logger)
        {
            this.tasks = tasks;
            map = mapper;
        }

        public async Task<TaskResponseDto> GetTaskbycartId(long CartId, CancellationToken cancellationToken = default)
        {
            var result = await tasks.GetTaskbycartId(CartId, cancellationToken);
            var mapped = map.Map<TaskResponseDto>(result);
            return mapped;
        }
    }
}
