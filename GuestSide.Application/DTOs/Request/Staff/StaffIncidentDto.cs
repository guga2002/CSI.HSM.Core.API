using Domain.Core.Entities.Enums;

namespace Core.Application.DTOs.Request.Staff;

public class StaffIncidentDto
{
    public long ReportedByStaffId { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public required PriorityEnum Severity { get; set; }

    public required StatusEnum Status { get; set; }

    public string? ResolutionNotes { get; set; }

    public required string Location { get; set; }

    public long IncidentTypeId { get; set; }
}
