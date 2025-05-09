using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Task;

[Table("Comments", Schema = "CSI")]
public class Comment : AbstractEntity
{
    public long StaffId { get; set; }

    [ForeignKey(nameof(Tasks))]

    public long TaskId { get; set; }

    public string? Text { get; set; }

    public long GuestId { get; set; }

    public virtual Tasks? Tasks { get; set; }
}