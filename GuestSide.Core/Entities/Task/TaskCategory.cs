using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Language;

namespace GuestSide.Core.Entities.Task;

[Table("TaskCategories",Schema = "CSI")]
public class TaskCategory:AbstractEntity
{
    public required string CategoryName { get; set; }

    public string? Description {  get; set; }

    [ForeignKey(nameof(languagePack))]
    public long LanguageId { get; set; }
    public LanguagePack languagePack { get; set; }
    public IEnumerable<Tasks> Tasks { get; set; }
}
