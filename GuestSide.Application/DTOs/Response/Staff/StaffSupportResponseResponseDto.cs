﻿namespace Core.Application.DTOs.Response.Staff;

public class StaffSupportResponseResponseDto
{
    public long Id { get; set; }

    public long TicketId { get; set; }

    public string? ResponderName { get; set; }

    public string? ResponseMessage { get; set; }

    public bool IsFromSupportTeam { get; set; } = false;

    public string? AttachmentUrlsSerialized { get; set; }
}
