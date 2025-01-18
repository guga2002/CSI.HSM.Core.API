namespace Core.Application.DTOs.Response.Guest;

public class GuestStatusResponseDto
{
    public long Id { get; set; }

    public required string StatusName { get; set; }

    public long LanguageId { get; set; }
}
