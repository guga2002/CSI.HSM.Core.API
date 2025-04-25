using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;
using Domain.Core.Entities.Staff;

namespace Domain.Core.Entities.Task;

[Table("Comments", Schema = "CSI")]
public class Comment : AbstractEntity
{
    [ForeignKey(nameof(Staff))]
    public long StaffId { get; set; }

    [ForeignKey(nameof(Tasks))]

    public long TaskId { get; set; }

    public string? Text { get; set; }

    public virtual Staffs? Staff { get; set; }

    public virtual Tasks? Tasks { get; set; }
}