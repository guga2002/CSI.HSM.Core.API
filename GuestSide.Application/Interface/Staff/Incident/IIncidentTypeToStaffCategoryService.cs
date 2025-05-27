using Common.Data.Entities.Staff;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Staff.Incident;

public interface IIncidentTypeToStaffCategoryService : IService
    <IncidentTypeToStaffCategoryDto, IncidentTypeToStaffCategoryResponseDto, long, IncidentTypeToStaffCategory>,
    IAdditionalFeatures<IncidentTypeToStaffCategoryDto, IncidentTypeToStaffCategoryResponseDto, long, IncidentTypeToStaffCategory>
{
}
