using Core.Application.DTOs.Response.Task;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Staff;

public class TaskToStaffResponseDto
{
    //date when the task is assigned to staff
    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    //date when the task is completed
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    public long StaffId { get; set; }

    //carts status
    public long StatusId { get; set; }

    public long TaskId { get; set; }

    public TaskStatusResponseDto Status { get; set; }
}
