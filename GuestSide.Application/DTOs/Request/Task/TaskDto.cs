using Core.Core.Entities.Task;
using TaskStatus = Core.Core.Entities.Task.TaskStatus;

namespace Core.Application.DTOs.Request.Task;

public class TaskDto
{
    public required string Title { get; set; }

    public required string Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? DueDate { get; set; }

    public bool IsCompleted { get; set; }

    public TaskStatus Status { get; set; }

    public TaskPriority Priority { get; set; }

    public string? LanguageCode { get; set; }

    public long CartId { get; set; }

    public string? Note { get; set; }

    public DateTime UpdatedAt { get; set; }
}
