using Core.Application.DTOs.Response;

namespace Core.Application.DTOs.Response.Staff;

public class IncidentTypeToStaffCategoryResponseDto : AbstractResponse
{
    public long StaffCategoryId { get; set; }

    public virtual StaffCategoryResponseDto? Category { get; set; }

    public long IncidentTypeId { get; set; }

    public virtual IncidentTypeResponseDto? IncidentType { get; set; }
}
