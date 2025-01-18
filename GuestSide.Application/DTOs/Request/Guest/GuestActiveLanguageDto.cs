namespace Core.Application.DTOs.Request.Guest;

public class GuestActiveLanguageDto
{
    public long GuestID { get; set; }
    public string LanguageCode { get; set; }
    public DateTime SetDate { get; set; }
}
