namespace Core.Application.DTOs.Request.Task;

public class TaskStatusDto
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public long LanguageId { get; set; }
}
