namespace Core.Application.DTOs.Request.Contacts;

public class ContactDto
{
    public required string Name { get; set; }

    public required string Mail { get; set; }

    public string? PhoneNumber { get; set; }

    public long StaffTypeId { get; set; }
}
