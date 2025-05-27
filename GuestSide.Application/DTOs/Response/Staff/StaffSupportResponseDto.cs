using Common.Data.Entities.Enums;
using Common.Data.Entities.Staff;
using Core.Application.DTOs.Response;

namespace Core.Application.DTOs.Response.Staff;

public class StaffSupportResponseDto : AbstractResponse
{
    public long StaffId { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; } // Categorizes the support request (e.g., "IT", "HR", "Facilities")

    public PriorityEnum Priority { get; set; }

    public StatusEnum Status { get; set; }

    public DateTime? ResolvedDate { get; set; }

    public List<string>? AttachmentUrls { get; set; }

    public virtual StaffSupportResponse? SupportResponse { get; set; } // Virtual for lazy loading

    public virtual StaffResponseDto? StaffMember { get; set; }
}