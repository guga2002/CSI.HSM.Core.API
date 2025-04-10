using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Domain.Core.Entities.Staff;
using Domain.Core.Sheared;

namespace Core.Application.Services.Staff.Cart.Mappper;

public class TaskToStaffMapper:Profile
{
    public TaskToStaffMapper()
    {
        CreateMap<TaskToStaffDto, TaskToStaff>().ReverseMap();
        CreateMap<TaskToStaff,TaskToStaffResponseDto>().ReverseMap();
        CreateMap<GroupTasksStatusByCardDto, GroupTasksStatusByCard>().ReverseMap();
    }
}
