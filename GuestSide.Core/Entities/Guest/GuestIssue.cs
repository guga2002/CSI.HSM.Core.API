//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Domain.Core.Entities.Enums;
//using Domain.Core.Entities.Staff;

//namespace Domain.Core.Entities.Guest;

//[Table("GuestIssues", Schema = "CSI")]
//public class GuestIssue
//{
//    [ForeignKey(nameof(Guests))]
//    public long GuestId { get; set; }

//    public required string Title { get; set; }

//    public string? Description { get; set; }

//    public required StatusEnum Status { get; set; } = StatusEnum.Open;

//    public DateTime? ResolvedAt { get; set; } 

//    [StringLength(300)]
//    public string? ResolutionNotes { get; set; } // Notes or steps taken to resolve the incident

//    [StringLength(100)]
//    public required string Location { get; set; } 

//    public bool RequiresImmediateAction { get; set; } = false; 

//    [ForeignKey(nameof(IncidentType))]
//    public long IncidentTypeId { get; set; }

//    public virtual IncidentType? IncidentType { get; set; }

//    public virtual Guests? Guests { get; set; } // Virtual for lazy loading
//}
