using AutoMapper;
using GuestSide.Application.DTOs.Task;
using GuestSide.Application.Interface.Task.Task;
using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Task.Status
{
    public class TasksService : GenericService<TaskDto, long, Tasks>, ITaskService
    {
        public TasksService(IMapper mapper, IGenericRepository<Tasks> repository, ILogger<GenericService<TaskDto, long, Tasks>> logger) : base(mapper, repository, logger)
        {
        }
    }
}
