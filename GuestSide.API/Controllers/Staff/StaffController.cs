using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Staff;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Staff;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Staff
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : CSIControllerBase<StaffDto, long, Staffs>
    {
        public StaffController(IService<StaffDto, long, Staffs> serviceProvider) : base(serviceProvider)
        {
        }
    }
}
