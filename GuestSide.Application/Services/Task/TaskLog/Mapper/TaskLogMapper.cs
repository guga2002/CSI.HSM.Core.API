using AutoMapper;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Core.Entities.Task;

namespace Core.Application.Services.Task.TaskLog.Mapper;

public class TaskLogMapper:Profile
{
    public TaskLogMapper()
    {
        CreateMap<TaskLogs,TaskLogDto>().ReverseMap();
        CreateMap<TaskLogs,TaskLogResponse>().ReverseMap();
    }
}
