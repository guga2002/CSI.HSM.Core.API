using Core.Core.Entities.Staff;

namespace Core.Application.DTOs.Response.Staff;

public class StaffSupportResponseDto
{
    public long StaffId { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public SupportTicketPriority Priority { get; set; } 

    public SupportTicketStatus Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ResolvedDate { get; set; }

    public DateTime UpdatedAt { get; set; } 

    public string? AttachmentUrlsSerialized { get; set; }
}
