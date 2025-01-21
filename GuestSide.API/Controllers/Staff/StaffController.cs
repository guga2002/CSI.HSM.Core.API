using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Core.Entities.Staff;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Staff;

[Route("api/[controller]")]
[ApiController]
public class StaffController : CSIControllerBase<StaffDto, StaffResponseDto, long, Staffs>
{
    public StaffController(IService<StaffDto, StaffResponseDto, long, Staffs> serviceProvider, IAdditionalFeatures<StaffDto, StaffResponseDto, long, Staffs> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
