using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Entities.Task;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Item;

[Table("TaskItems", Schema = "CSI")]
public class TaskItem: AbstractEntity
{
    [ForeignKey(nameof(Tasks))]
    public long TaskId { get; set; }
    public virtual Tasks Task { get; set; }

    [ForeignKey(nameof(Items))]
    public long ItemId { get; set; }
    public virtual Items Item { get; set; }

    public int Quantity { get; set; }
}
