using AutoMapper;
using Common.Data.Entities.Staff;
using Common.Data.Sheared;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;

namespace Core.Application.Services.Staff.Cart.Mappper;

public class TaskToStaffMapper : Profile
{
    public TaskToStaffMapper()
    {
        CreateMap<TaskToStaffDto, TaskToStaff>().ReverseMap();
        CreateMap<TaskToStaff, TaskToStaffResponseDto>().ReverseMap();
        CreateMap<GroupTasksStatusByCardDto, GroupTasksStatusByCard>().ReverseMap();
    }
}
