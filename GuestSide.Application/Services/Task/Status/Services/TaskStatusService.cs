using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Application.Interface.Task.Status;
using GuestSide.Application.Services;
using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.AbstractInterface;
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
