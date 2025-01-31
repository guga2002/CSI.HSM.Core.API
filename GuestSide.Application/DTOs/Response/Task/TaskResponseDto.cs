using System.ComponentModel.DataAnnotations;
using Core.Core.Entities.Item;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Entities.Language;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Application.DTOs.Response.Item;

namespace GuestSide.Application.DTOs.Response.Task;

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