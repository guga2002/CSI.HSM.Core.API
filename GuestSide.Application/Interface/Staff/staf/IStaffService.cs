using GuestSide.Application.DTOs.Staff;
using GuestSide.Core.Entities.Staff;

namespace GuestSide.Application.Interface.Staff.staf
{
    public interface IStaffService : IService<StaffDto,long,Staffs>
    {
    }
}
