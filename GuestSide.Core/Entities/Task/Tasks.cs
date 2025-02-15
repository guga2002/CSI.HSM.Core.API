using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.FeedBacks;
using Core.Core.Entities.Item;
using Core.Core.Entities.Language;

namespace Core.Core.Entities.Task;

[Table("Tasks", Schema = "CSI")]
public class Tasks : AbstractEntity
{
    [StringLength(100)]
    public required string Title { get; set; }

    [StringLength(100)]
    public required string Description { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(LanguagePack))]
    public long LanguageId { get; set; }
    public virtual LanguagePack? LanguagePack { get; set; }

    public virtual IEnumerable<Feedback>? Feedbacks { get; set; }

    [ForeignKey(nameof(Cart))]
    public long CartId { get; set; }
    public virtual Cart? Cart { get; set; }

    public virtual ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();

    [StringLength(100)]
    public string? Note { get; set; }

    public decimal Total => TaskItems.Sum(io => io.Item.Price * io.Quantity) ?? 0;
}
