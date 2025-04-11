using Core.Application.DTOs.Response;

namespace Core.Application.DTOs.Response.Contacts;

public class ContactResponseDto : AbstractResponse
{
    public string? Name { get; set; }

    public string? Mail { get; set; }

    public string? PhoneNumber { get; set; }

    public long StaffTypeId { get; set; }

    public virtual ContactsStaffTypeResponseDto? StaffType { get; set; }
}
