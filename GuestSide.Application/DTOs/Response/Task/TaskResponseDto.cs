using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Application.DTOs.Response.Item;
using Core.Core.Entities.Item;
using Core.Core.Entities.Task;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace Core.Application.DTOs.Response.Task;

public class TaskResponseDto
{
    public virtual ICollection<TaskItemResponseDto> TaskItems { get; set; }

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