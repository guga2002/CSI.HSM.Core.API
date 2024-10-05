using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Staff;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Staff;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Staff
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffToCartController : CSIControllerBase<CartToStaffDto, long, CartToStaff>
    {
        public StaffToCartController(IService<CartToStaffDto, long, CartToStaff> serviceProvider) : base(serviceProvider)
        {
        }
    }
}
