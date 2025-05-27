using AutoMapper;
using Common.Data.Entities.Task;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;

namespace Core.Application.Services.Task.Task.Mapper;

public class TaskMapper : Profile
{
    public TaskMapper()
    {
        CreateMap<TaskDto, Tasks>().ReverseMap();

        CreateMap<Tasks, TaskResponseDto>();
    }
}
