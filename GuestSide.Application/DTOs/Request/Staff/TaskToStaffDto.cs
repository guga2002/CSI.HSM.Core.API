using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Entities.Task;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Application.DTOs.Request.Staff;

public class TaskToStaffDto
{
    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    public long StaffCategoryId { get; set; }

    public long StatusId { get; set; }

    public long TaskId { get; set; }
}
