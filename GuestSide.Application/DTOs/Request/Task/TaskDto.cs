using Core.Core.Entities.Enums;
namespace Core.Application.DTOs.Request.Task;

public class TaskDto
{
    public required string Title { get; set; }

    public required string Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? DueDate { get; set; }

    public bool IsCompleted { get; set; }

    public StatusEnum Status { get; set; } 

    public PriorityEnum Priority { get; set; }

    public string? LanguageCode { get; set; }

    public long CartId { get; set; }

    public string? Note { get; set; }
}
