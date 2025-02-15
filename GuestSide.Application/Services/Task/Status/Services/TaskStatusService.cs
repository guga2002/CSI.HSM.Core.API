using AutoMapper;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.Task.Status;
using Core.Core.Entities.Task;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Task.Status.Services;

public class TaskStatusService : GenericService<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus>, ITaskStatusService
{
    public TaskStatusService(IMapper mapper, 
        IGenericRepository<TasksStatus> repository, 
        ILogger<GenericService<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus>> logger, 
        IAdditionalFeaturesRepository<TasksStatus> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
