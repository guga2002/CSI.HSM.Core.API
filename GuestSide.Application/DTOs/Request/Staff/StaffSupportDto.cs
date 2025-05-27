using Common.Data.Entities.Enums;

namespace Core.Application.DTOs.Request.Staff;

public class StaffSupportDto
{
    public long StaffId { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public PriorityEnum Priority { get; set; } = PriorityEnum.Medium;

    public List<string>? AttachmentUrls { get; set; }
}
