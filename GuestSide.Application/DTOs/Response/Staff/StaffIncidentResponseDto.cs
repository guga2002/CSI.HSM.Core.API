using Core.Core.Entities.Staff;

namespace Core.Application.DTOs.Response.Staff;

public class StaffIncidentResponseDto
{
    public long Id { get; set; }

    public long ReportedByStaffId { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public DateTime ReportedAt { get; set; }

    public Severity Severity { get; set; }

    public StaffIncidentStatus Status { get; set; }

    public DateTime? ResolvedAt { get; set; } 

    public string? ResolutionNotes { get; set; }

    public required string Location { get; set; } 

    public bool RequiresImmediateAction { get; set; } 

    public string? IncidentType { get; set; } 

    public DateTime UpdatedAt { get; set; } 

    public virtual Staffs? ReportedByStaff { get; set; }
}
