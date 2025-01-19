using AutoMapper;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Core.Entities.Task;

namespace Core.Application.Services.Task.Status.Mapper;

public class TaskStatusMapper:Profile
{
    public TaskStatusMapper()
    {
        CreateMap<TaskStatusDto, TasksStatus>().ReverseMap();
        CreateMap<TasksStatus, TaskStatusResponseDto>().ReverseMap();
    }
}
