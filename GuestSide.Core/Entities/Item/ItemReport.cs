using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;
using Domain.Core.Entities.Enums;

namespace Domain.Core.Entities.Item;

[Table("ItemReports", Schema = "CSI")]
public class ItemReport : AbstractEntity
{
    [ForeignKey(nameof(Items))]
    public long ItemId { get; set; }

    public virtual Items? Items { get; set; }

    public long reportedByUserId {  get; set; } //guest-is id romelmac daareporta

    public StatusEnum? Status { get; set; }

    public string? ReportReason {  get; set; }
}
