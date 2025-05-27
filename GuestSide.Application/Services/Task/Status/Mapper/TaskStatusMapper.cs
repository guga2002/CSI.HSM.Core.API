using AutoMapper;
using Common.Data.Entities.Task;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;

namespace Core.Application.Services.Task.Status.Mapper;

public class TaskStatusMapper : Profile
{
    public TaskStatusMapper()
    {
        CreateMap<TaskStatusDto, TasksStatus>().ReverseMap();
        CreateMap<TasksStatus, TaskStatusResponseDto>().ReverseMap();
    }
}
