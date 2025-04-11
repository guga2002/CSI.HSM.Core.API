using Domain.Core.Entities.Item;
using Domain.Core.Entities.Enums;
using Domain.Core.Entities.FeedBacks;
using Domain.Core.Entities.Staff;
using Core.Application.DTOs.Response;
using Core.Application.DTOs.Response.Item;
using Core.Application.DTOs.Response.Staff;
using Core.Application.DTOs.Response.FeedBacks;

namespace Core.Application.DTOs.Response.Task;

public class TaskResponseDto : AbstractResponse
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; } // Expected completion date

    public bool IsCompleted { get; set; } = false; // Indicates whether the task is completed

    public StatusEnum Status { get; set; }

    public PriorityEnum Priority { get; set; }

    public string? LanguageCode { get; set; }

    public long CartId { get; set; }

    public virtual CartResponseDto? Cart { get; set; }

    public string? Note { get; set; }

    public virtual List<FeedbackResponseDto>? Feedbacks { get; set; }

    public virtual List<TaskItemResponseDto>? TaskItems { get; set; }

    public virtual TaskToStaffResponseDto? TaskToStaff { get; set; }
}