namespace Core.Application.DTOs.Request.Task;

public class TaskLogDto
{
    public long TaskId { get; set; }

    public required string Action { get; set; }

    public required string PerformedBy { get; set; }

    public string? Notes { get; set; }
}
