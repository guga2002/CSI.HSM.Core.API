using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Task;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Staff;

[Table("TaskToStaffs", Schema = "CSI")]
public class TaskToStaff : AbstractEntity
{
    //date when the task is assigned to staff
    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    //date when the task is completed
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    [ForeignKey(nameof(Staff))]
    public long StaffId { get; set; }

    public virtual Staffs Staff { get; set; }

    //carts status

    [ForeignKey(nameof(Status))]
    public long StatusId { get; set; }

    public TasksStatus Status { get; set; }


    [ForeignKey(nameof(Task))]
    public long TaskId { get; set; }

    public Tasks Task { get; set; }
}