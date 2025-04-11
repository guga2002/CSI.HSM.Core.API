using Core.Application.DTOs.Response;
using Core.Application.DTOs.Response.Staff;

namespace Core.Application.DTOs.Response.Task;

public class TaskStatusResponseDto : AbstractResponse
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? LanguageCode { get; set; }

    public virtual List<TaskToStaffResponseDto>? TaskToStaff { get; set; }
}
