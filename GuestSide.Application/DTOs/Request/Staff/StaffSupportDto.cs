using Core.Core.Entities.Staff;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Application.DTOs.Request.Staff;

public class StaffSupportDto
{
    public long StaffId { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; } 

    public SupportTicketPriority Priority { get; set; } = SupportTicketPriority.Medium; 

    [Column(TypeName = "nvarchar(max)")]
    public string? AttachmentUrlsSerialized { get; set; }
}
