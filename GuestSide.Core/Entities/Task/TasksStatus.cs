using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Language;
using GuestSide.Core.Entities.Staff;

namespace GuestSide.Core.Entities.Task;

[Table("TaskStatus",Schema = "CSI")]
public class TasksStatus:AbstractEntity
{
    [Column("NameOfStatus")]
    public required string Name { get; set; }

    public string? Description { get; set; }

    [ForeignKey(nameof(languagePack))]
    public long LanguageId { get; set; }

    public virtual LanguagePack? languagePack { get; set; }

    public virtual IEnumerable<TaskToStaff>?taskToStaff { get; set; }
}
