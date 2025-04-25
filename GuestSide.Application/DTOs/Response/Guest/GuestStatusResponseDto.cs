using System.ComponentModel.DataAnnotations;
using Core.Application.DTOs.Response;

namespace Core.Application.DTOs.Response.Guest;

public class GuestStatusResponseDto : AbstractResponse
{
    public string? StatusName { get; set; }

    [StringLength(10)]
    public string? LanguageCode { get; set; }
}
