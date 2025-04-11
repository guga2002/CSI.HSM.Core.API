using AutoMapper;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.Task.TaskLogs;
using Domain.Core.Entities.Task;
using Domain.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Task.TaskLog.Service;

public class TaskLogsService : GenericService<TaskLogDto, TaskLogResponse, long, TaskLogs>, ITaskLogsService
{
    public TaskLogsService(IMapper mapper, IGenericRepository<TaskLogs> repository, ILogger<GenericService<TaskLogDto, TaskLogResponse, long, TaskLogs>> logger, IAdditionalFeaturesRepository<TaskLogs> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
