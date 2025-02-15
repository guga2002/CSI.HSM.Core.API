using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;

namespace Core.Core.Entities.Staff;

[Table("StaffIncidents", Schema = "CSI")]
public class StaffIncident : AbstractEntity
{
    [ForeignKey(nameof(StaffMember))]
    public long ReportedByStaffId { get; set; }
    [StringLength(100)] 
    public required string Title { get; set; } // Short summary of the incident
    [StringLength(500)] 
    public string? Description { get; set; } // Detailed description of what happened
    public DateTime ReportedAt { get; set; } // Timestamp when the incident was reported

    [StringLength(100)]
    public required string Severity { get; set; } // Incident severity: "Low", "Medium", "High", "Critical"

    [StringLength(500)] 
    public required string Status { get; set; } // "Open", "In Progress", "Resolved", "Closed"
    public DateTime? ResolvedAt { get; set; } // Timestamp when the incident was resolved
    [StringLength(300)]
    public string? ResolutionNotes { get; set; } // Notes or steps taken to resolve the incident

    [StringLength(100)]
    public required string Location { get; set; } // Physical location of the incident (e.g., "Room 203", "Lobby")

    public bool RequiresImmediateAction { get; set; }

    public Staffs StaffMember { get; set; }
}