using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Application.Interface.Task.Task;
using GuestSide.Application.Services;
using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Task.Task.Services
{
    public class TasksService : GenericService<TaskDto, TaskResponseDto, long, Tasks>, ITaskService
    {
        private readonly IGenericRepository<Tasks> tasks;
        private readonly IMapper map;

        public TasksService(IMapper mapper, IGenericRepository<Tasks> repository, ILogger<GenericService<TaskDto, TaskResponseDto, long, Tasks>> logger, IAdditionalFeaturesRepository<Tasks> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
        {
            tasks = repository;
            map = mapper;
        }

        public async Task<IEnumerable<TaskResponseDto>> GetTasksbycartId(long CartId, CancellationToken cancellationToken = default)
        {
            var result = await tasks.GetByIdAsync(CartId, cancellationToken);
            var mapped = map.Map<IEnumerable<TaskResponseDto>>(result);
            return mapped;
        }
    }
}
