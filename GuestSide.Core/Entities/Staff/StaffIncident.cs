using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Staff
{
    [Table("StaffIncidents", Schema = "CSI")]
    [Index(nameof(ReportedByStaffId))] 
    [Index(nameof(Severity))] 
    [Index(nameof(Status))] 
    [Index(nameof(RequiresImmediateAction))] 
    [Index(nameof(ReportedAt))] 
    public class StaffIncident : AbstractEntity
    {
        [ForeignKey(nameof(ReportedByStaff))]
        public long ReportedByStaffId { get; set; } 

        [StringLength(100)]
        public required string Title { get; set; } 

        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime ReportedAt { get; set; } = DateTime.UtcNow; 

        [StringLength(100)]
        public required string Severity { get; set; } // "Low", "Medium", "High", "Critical"

        [StringLength(100)]
        public required string Status { get; set; } = "Open"; // "Open", "In Progress", "Resolved", "Closed"

        public DateTime? ResolvedAt { get; set; } // Timestamp when the incident was resolved

        [StringLength(300)]
        public string? ResolutionNotes { get; set; } // Notes or steps taken to resolve the incident

        [StringLength(100)]
        public required string Location { get; set; } // Location of the incident (e.g., "Room 203", "Lobby")

        public bool RequiresImmediateAction { get; set; } = false; // Marks if urgent attention is needed

        [StringLength(100)]
        public string? IncidentType { get; set; } // Categorizes the type of incident (e.g., "Safety", "Technical", "HR")

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Tracks last modification time

        public virtual Staffs? ReportedByStaff { get; set; } // Virtual for lazy loading
    }
}
