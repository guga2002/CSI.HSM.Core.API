using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Task;

[Table("Priorities", Schema = "CSI")]
public class Priority : AbstractEntity
{
    public required string Name { get; set; }

    public virtual List<Tasks>? Tasks { get; set; }
}
