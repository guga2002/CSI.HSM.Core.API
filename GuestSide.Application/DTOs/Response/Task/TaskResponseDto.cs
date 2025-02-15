using Core.Application.DTOs.Response.Item;

namespace Core.Application.DTOs.Response.Task;

public class TaskResponseDto
{
    public required string Title { get; set; }

    public required string Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public long LanguageId { get; set; }

    public long CartId { get; set; }

    public virtual ICollection<TaskItemResponseDto> TaskItems { get; set; }

    public string? Note { get; set; }

    public decimal Total { get; set; }
}