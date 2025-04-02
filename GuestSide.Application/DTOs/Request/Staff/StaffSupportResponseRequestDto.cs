namespace Core.Application.DTOs.Request.Staff;

public class StaffSupportResponseRequestDto
{
    public long TicketId { get; set; }

    public string? ResponderName { get; set; }

    public string? ResponseMessage { get; set; }

    public bool IsFromSupportTeam { get; set; } = false;

    public string? AttachmentUrlsSerialized { get; set; }
}
