namespace Core.Application.DTOs.Response.Guest;

public class GuestActiveLanguageResponseDto : AbstractResponse
{
    public long GuestId { get; set; }

    public string? LanguageCode { get; set; }

    //public DateTime SetDate { get; set; } 
}