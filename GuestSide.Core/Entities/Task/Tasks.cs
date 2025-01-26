using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.Item;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Entities.Language;

namespace GuestSide.Core.Entities.Task;

[Table("Tasks", Schema = "CSI")]
public class Tasks : AbstractEntity
{
    public required string Title { get; set; }

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

    public string? Note { get; set; }
}
