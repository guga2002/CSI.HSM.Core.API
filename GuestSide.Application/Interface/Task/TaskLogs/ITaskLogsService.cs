﻿using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Task.TaskLogs;

public interface ITaskLogsService : IService<TaskLogDto, TaskLogResponse, long, Common.Data.Entities.Task.TaskLogs>,
        IAdditionalFeatures<TaskLogDto, TaskLogResponse, long, Common.Data.Entities.Task.TaskLogs>
{
}
