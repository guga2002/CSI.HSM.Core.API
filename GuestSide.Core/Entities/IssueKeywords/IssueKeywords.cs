using Domain.Core.Entities.AbstractEntities;
using Domain.Core.Entities.Item;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities.IssueKeywords;

[Table("IssueKeywords", Schema = "CSI")]
public class IssueKeyword : AbstractEntity
{
    public string KeyWord { get; set; }
    public List<TaskItem> TaskItems { get; set; }
}
