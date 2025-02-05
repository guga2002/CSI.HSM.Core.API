using AutoMapper;
using Core.Application.DTOs.Response.Staff;
using Core.Core.Sheared;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Core.Entities.Staff;

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
