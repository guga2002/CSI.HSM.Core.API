using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Core.Entities.Item;

[Table("ScheduledDeliveries", Schema = "CSI")]
public class ScheduledDelivery : AbstractEntity
{
    [ForeignKey(nameof(TaskItem))]
    public long TaskItemId { get; set; }

    public virtual TaskItem? TaskItem { get; set; }

    public DateTime ScheduledDateTime { get; set; }

    public string? Note {  get; set; }
}
