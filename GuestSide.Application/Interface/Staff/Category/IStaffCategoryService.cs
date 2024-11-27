using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Core.Entities.Staff;

namespace GuestSide.Application.Interface.Staff.Category
{
    public interface IStaffCategoryService : IService<StaffCategoryDto,StaffCategoryResponseDto,long, GuestSide.Core.Entities.Staff.StaffCategory>
    {
    }
}
