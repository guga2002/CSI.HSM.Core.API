using Core.Core.Entities.Enums;

namespace Core.Application.DTOs.Response.Staff;

public class StaffIncidentResponseDto : AbstractResponse
{
    public long ReportedByStaffId { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public DateTime ReportedAt { get; set; }

    public required PriorityEnum Severity { get; set; }

    public required StatusEnum Status { get; set; }

    public DateTime? ResolvedAt { get; set; } 

    public string? ResolutionNotes { get; set; }

    public required string Location { get; set; } 

    public bool RequiresImmediateAction { get; set; }

    public long IncidentTypeId { get; set; }

    public virtual StaffResponseDto? ReportedByStaff { get; set; }

    public virtual IncidentTypeResponseDto? IncidentType { get; set; }
}
