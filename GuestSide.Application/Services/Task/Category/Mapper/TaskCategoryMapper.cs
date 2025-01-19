using AutoMapper;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Core.Entities.Task;

namespace Core.Application.Services.Task.Category.Mapper;

public class TaskCategoryMapper:Profile
{
    public TaskCategoryMapper()
    {
        CreateMap<TaskCategoryDto, TaskCategory>().ReverseMap();
        CreateMap<TaskCategory, TaskCategoryResponseDto>().ReverseMap();
    }
}
