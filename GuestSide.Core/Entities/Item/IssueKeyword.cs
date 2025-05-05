using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Item;

[Table("IssueKeywords", Schema = "CSI")]
public class IssueKeyword : AbstractEntity
{
    public string? Keyword { get; set; }

    public virtual List<TaskItem>? TaskItem { get; set; }
}
