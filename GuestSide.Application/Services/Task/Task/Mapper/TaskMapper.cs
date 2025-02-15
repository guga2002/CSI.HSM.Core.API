using AutoMapper;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Core.Entities.Task;

namespace Core.Application.Services.Task.Task.Mapper;

public class TaskMapper:Profile
{
    public TaskMapper()
    {
        CreateMap<TaskDto, Tasks>().ReverseMap();

        CreateMap<Tasks, TaskResponseDto>();
    }
}
