using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Language;

public class LanguagePackResponseDto
{
    public long Id { get; set; }
    public required string Code { get; set; }

    public required string Name { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } 

    public DateTime UpdatedAt { get; set; } 
}
