using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Task;

public class TaskStatusResponseDto
{
    public long Id { get; set; }

    public required string Name { get; set; }

     public string? Description { get; set; }

    public string? LanguageCode { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
