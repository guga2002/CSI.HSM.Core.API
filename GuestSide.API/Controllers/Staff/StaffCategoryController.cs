using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Staff;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Staff;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Staff
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffCategoryController : CSIControllerBase<StaffCategoryDto, long, StaffCategory>
    {
        public StaffCategoryController(IService<StaffCategoryDto, long, StaffCategory> serviceProvider) : base(serviceProvider)
        {
        }
        //add more  methods there
    }
}
