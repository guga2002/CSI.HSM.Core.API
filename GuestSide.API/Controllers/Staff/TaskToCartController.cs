using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Core.Entities.Staff;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Staff;

[Route("api/[controller]")]
[ApiController]
public class TaskToCartController : CSIControllerBase<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>
{
    public TaskToCartController(IService<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff> serviceProvider, IAdditionalFeatures<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
