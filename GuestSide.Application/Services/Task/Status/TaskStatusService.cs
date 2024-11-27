﻿using AutoMapper;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Application.Interface.Task.Status;
using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Task.Status
{
    public class TaskStatusService : GenericService<TaskStatusDto,TaskStatusResponseDto, long, Core.Entities.Task.TasksStatus>, ITaskStatusService
    {
        public TaskStatusService(IMapper mapper, IGenericRepository<TasksStatus> repository, ILogger<GenericService<TaskStatusDto,TaskStatusResponseDto, long, TasksStatus>> logger) : base(mapper, repository, logger)
        {
        }
    }
}
