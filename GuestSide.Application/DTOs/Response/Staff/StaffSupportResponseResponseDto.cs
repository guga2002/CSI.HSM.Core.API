using Core.Core.Entities.Staff;

namespace Core.Application.DTOs.Response.Staff;

public class StaffSupportResponseResponseDto : AbstractResponse
{
    public long TicketId { get; set; } 

    public virtual StaffSupport? StaffSupport { get; set; } // Virtual for lazy loading

    public string? ResponderName { get; set; } 

    public string? ResponseMessage { get; set; }

    public bool IsFromSupportTeam { get; set; } = false; 

    public List<string>? AttachmentUrls {  get; set; }
}
