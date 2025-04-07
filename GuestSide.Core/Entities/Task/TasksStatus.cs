using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Staff;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Task;

[Table("TaskStatus", Schema = "CSI")]
[Index(nameof(Name), IsUnique = true)]
public class TasksStatus : AbstractEntity, IExistable<TasksStatus>
{
    [Column("NameOfStatus")]
    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(255)] 
    public string? Description { get; set; }

    public virtual List<TaskToStaff>? TaskToStaff { get; set; }

    public Expression<Func<TasksStatus, bool>> GetExistencePredicate()
    {
        return taskStatus => taskStatus.Name == Name;
    }
}
