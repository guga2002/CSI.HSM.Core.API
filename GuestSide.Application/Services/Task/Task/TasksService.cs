using AutoMapper;
using GuestSide.Application.DTOs.Task;
using GuestSide.Application.Interface.Task.Task;
using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Task;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Task.Status
{
    public class TasksService : GenericService<TaskDto, long, Tasks>, ITaskService
    {
        private readonly ITaskRepository tasks;
        private readonly IMapper map;
        public TasksService(ITaskRepository tasks, IMapper mapper, IGenericRepository<Tasks> repository, ILogger<GenericService<TaskDto, long, Tasks>> logger) : base(mapper, repository, logger)
        {
            this.tasks = tasks;
            this.map=mapper;
        }

        public async Task<TaskDto> GetTaskbycartId(long CartId, CancellationToken cancellationToken = default)
        {
            var result = await tasks.GetTaskbycartId(CartId, cancellationToken);
            var mapped = map.Map<TaskDto>(result);
            return mapped;
        }
    }
}
