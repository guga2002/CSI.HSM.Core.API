using Domain.Core.Entities.AbstractEntities;
using Domain.Core.Entities.Task;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities.Item;

[Table("TaskItems", Schema = "CSI")]
[Index(nameof(TaskId))] // Optimized for task-item lookups
[Index(nameof(ItemId))] // Optimized for item-task lookups
public class TaskItem : AbstractEntity
{
    [ForeignKey(nameof(Task))]
    public long TaskId { get; set; }

    public virtual Tasks Task { get; set; }

    [ForeignKey(nameof(Item))]
    public long ItemId { get; set; }

    public virtual Items Item { get; set; }

    public int Quantity { get; set; }

    [StringLength(300)]
    public string? Notes { get; set; }

    [ForeignKey(nameof(IssueKeyword))]
    public long? IssueKeywordId {  get; set; }

    public virtual IssueKeyword? IssueKeyword { get; set; }

    public virtual ScheduledDelivery? ScheduledDelivery { get; set; }

    public List<ItemReportAttachment> ReportAttachments { get; set; }
}