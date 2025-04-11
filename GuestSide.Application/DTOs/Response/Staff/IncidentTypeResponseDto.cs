using Core.Application.DTOs.Response;

namespace Core.Application.DTOs.Response.Staff;

public class IncidentTypeResponseDto : AbstractResponse
{
    public required string Type { get; set; }

    public string? Description { get; set; }

    public virtual List<StaffIncidentResponseDto>? Incidents { get; set; }

    public virtual List<IncidentTypeToStaffCategoryResponseDto>? IncidentTypeToStaffCategories { get; set; }
}
