using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Staff;

namespace Core.Application.Interface.Staff.Category;

public interface IStaffCategoryService : IService<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory>,
    IAdditionalFeatures<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory>
{
}
