using AutoMapper;
using GuestSide.Application.DTOs.Task;
using GuestSide.Application.Interface.Task.Status;
using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Task.Status
{
    public class TaskStatusService : GenericService<TaskStatusDto, long, Core.Entities.Task.TasksStatus>, ITaskStatusService
    {
        public TaskStatusService(IMapper mapper, IGenericRepository<TasksStatus> repository, ILogger<GenericService<TaskStatusDto, long, TasksStatus>> logger) : base(mapper, repository, logger)
        {
        }
    }
}
