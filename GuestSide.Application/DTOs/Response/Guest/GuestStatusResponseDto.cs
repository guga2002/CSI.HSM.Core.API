using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Guest;

public class GuestStatusResponseDto
{
    public long Id { get; set; }

    public string? StatusName { get; set; }

    [StringLength(10)] 
    public string? LanguageCode { get; set; }
}
