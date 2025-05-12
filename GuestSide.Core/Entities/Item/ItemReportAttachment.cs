using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Item;

[Table("ItemReportAttachments", Schema = "CSI")]
public class ItemReportAttachment : AbstractEntity
{
    [ForeignKey(nameof(TaskItem))]
    public long? TaskItemId { get; set; }

    public virtual TaskItem? TaskItem { get; set; } 

    public string? FileName { get; set; }

    public string? FileUrl { get; set; }

    public string? FileType { get; set; }
}
