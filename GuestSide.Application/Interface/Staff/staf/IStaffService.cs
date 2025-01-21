using Core.Application.Interface.GenericContracts;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Core.Entities.Staff;

namespace GuestSide.Application.Interface.Staff.staf;

public interface IStaffService : IService<StaffDto,StaffResponseDto,long,Staffs>,
    IAdditionalFeatures<StaffDto, StaffResponseDto, long, Staffs>
{
}
