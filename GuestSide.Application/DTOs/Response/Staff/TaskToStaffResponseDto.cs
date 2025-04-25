using Core.Application.DTOs.Response;
using Core.Application.DTOs.Response.Task;
using Domain.Core.Entities.Staff;
using Domain.Core.Entities.Task;

namespace Core.Application.DTOs.Response.Staff;

public class TaskToStaffResponseDto : AbstractResponse
{
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public long StatusId { get; set; }

    public long TaskId { get; set; }

    public bool IsCompleted { get; set; } = false;

    public long? AssignedBy { get; set; }

    public virtual StaffResponseDto? AssignedByStaff { get; set; }

    public virtual TaskStatusResponseDto? Status { get; set; }

    public virtual TaskResponseDto? Task { get; set; }
}
