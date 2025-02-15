using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Staff;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Task;

[Table("TaskStatus", Schema = "CSI")]
[Index(nameof(Name), IsUnique = true)]
[Index(nameof(LanguageCode))]
[Index(nameof(IsActive))]
[Index(nameof(CreatedAt))]
public class TasksStatus : AbstractEntity
{
    [Column("NameOfStatus")]
    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(255)] public string? Description { get; set; }

    [StringLength(10)] public string? LanguageCode { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public virtual List<TaskToStaff>? TaskToStaff { get; set; }
}
