using Core.Application.DTOs.Response;

namespace Core.Application.DTOs.Response.Contacts;

public class ContactsStaffTypeResponseDto : AbstractResponse
{
    public string? StaffType { get; set; }

    public virtual List<ContactResponseDto>? Contacts { get; set; }
}
