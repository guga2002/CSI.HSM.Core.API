using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Core.Entities.Staff;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Staff
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffCategoryController : CSIControllerBase<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory>
    {
        public StaffCategoryController(IService<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory> serviceProvider, IAdditionalFeatures<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory> additionalFeatures) : base(serviceProvider, additionalFeatures)
        {
        }
    }
}
