using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Staff;

namespace Core.Core.Entities.Task;

[Table("TaskStatus", Schema = "CSI")]
public class TasksStatus : AbstractEntity
{
    [Column("NameOfStatus")]
    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(100)]
    public string? Description { get; set; }

    [StringLength(100)]
    public string? LanguageCode { get; set; }

    public virtual IEnumerable<TaskToStaff>? TaskToStaff { get; set; }
}
