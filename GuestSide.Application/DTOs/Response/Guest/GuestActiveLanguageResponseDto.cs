
using Core.Core.Entities.Guest;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Guest;

public class GuestActiveLanguageResponseDto
{
    public long Id { get; set; }
    public long GuestId { get; set; }

    public string? LanguageCode { get; set; }

    public DateTime SetDate { get; set; } 
}
