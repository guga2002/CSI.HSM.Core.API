using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;

namespace Core.Core.Entities.Staff;

[Table("StaffSupports", Schema = "CSI")]
public class StaffSupport : AbstractEntity
{
    [ForeignKey(nameof(StaffMember))]
    public long StaffId { get; set; }
    public string? Subject { get; set; }
    public string? Description { get; set; }
    public SupportTicketPriority Priority { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ResolvedDate { get; set; }
    public SupportTicketStatus Status { get; set; }
    public IEnumerable<string>? AttachmentUrls { get; set; }

    public Staffs? StaffMember { get; set; }

    public StaffSupportResponse? SupportResponse { get; set; }
}
public enum SupportTicketPriority
{
    Low,
    Medium,
    High,
    Critical
}

public enum SupportTicketStatus
{
    Open,
    InProgress,
    Resolved,
    Closed
}
