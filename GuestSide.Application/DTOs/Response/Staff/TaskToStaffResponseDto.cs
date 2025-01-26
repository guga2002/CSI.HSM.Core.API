using System.ComponentModel.DataAnnotations;

namespace GuestSide.Application.DTOs.Response.Staff;

public class TaskToStaffResponseDto
{
    public long Id { get; set; }

    //date when the task is assigned to staff
    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    //date when the task is completed
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    public long StaffCategoryId { get; set; }

    public long StatusId { get; set; }

    public long TaskId { get; set; }
}
