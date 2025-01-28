using AutoMapper;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Core.Entities.Task;

namespace Core.Application.Services.Task.Task.Mapper;

public class TaskMapper:Profile
{
    public TaskMapper()
    {
        CreateMap<TaskDto, Tasks>().ReverseMap();

        CreateMap<Tasks, TaskResponseDto>()
        .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total));
    }
}
