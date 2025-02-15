
namespace Core.Application.DTOs.Response.Guest;

public class GuestActiveLanguageResponseDto
{
    public long Id { get; set; }
    public long GuestID { get; set; }
    public string? LanguageCode { get; set; }
    public DateTime SetDate { get; set; }
}
