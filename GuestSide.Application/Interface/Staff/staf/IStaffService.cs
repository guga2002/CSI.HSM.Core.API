using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Staff;

namespace Core.Application.Interface.Staff.staf;

public interface IStaffService : IService<StaffDto, StaffResponseDto, long, Staffs>,
    IAdditionalFeatures<StaffDto, StaffResponseDto, long, Staffs>
{
}
