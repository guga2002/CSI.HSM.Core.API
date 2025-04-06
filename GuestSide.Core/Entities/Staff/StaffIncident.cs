using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Staff;

[Table("StaffIncidents", Schema = "CSI")]
[Index(nameof(ReportedByStaffId))] 
[Index(nameof(Severity))] 
[Index(nameof(Status))] 
[Index(nameof(RequiresImmediateAction))] 
public class StaffIncident : AbstractEntity
{
    [ForeignKey(nameof(ReportedByStaff))]
    public long ReportedByStaffId { get; set; } 

    [StringLength(100)]
    public required string Title { get; set; } 

    [StringLength(500)]
    public string? Description { get; set; }

    public required PriorityEnum Severity { get; set; } 

    public required StatusEnum Status { get; set; } = StatusEnum.Open;

    public DateTime? ResolvedAt { get; set; } // Timestamp when the incident was resolved

    [StringLength(300)]
    public string? ResolutionNotes { get; set; } // Notes or steps taken to resolve the incident

    [StringLength(100)]
    public required string Location { get; set; } // Location of the incident (e.g., "Room 203", "Lobby")

    public bool RequiresImmediateAction { get; set; } = false; // Marks if urgent attention is needed

    [ForeignKey(nameof(IncidentType))]
    public long IncidentTypeId {  get; set; }

    public virtual IncidentType? IncidentType { get; set; }

    public virtual Staffs? ReportedByStaff { get; set; } // Virtual for lazy loading
}