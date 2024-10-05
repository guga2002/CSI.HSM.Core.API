using GuestSide.Application.DTOs.Staff;
using GuestSide.Core.Entities.Staff;

namespace GuestSide.Application.Interface.Staff.Category
{
    public interface IStaffCategoryService : IService<StaffCategoryDto,long, GuestSide.Core.Entities.Staff.StaffCategory>
    {
    }
}
