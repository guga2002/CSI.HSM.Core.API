using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Request.Guest;

public class StatusDto
{

    public string? StatusName { get; set; }

    public string? LanguageCode { get; set; }
}
