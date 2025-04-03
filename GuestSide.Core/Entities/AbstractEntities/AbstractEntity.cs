using System.ComponentModel.DataAnnotations;

namespace Core.Core.Entities.AbstractEntities;

public abstract class AbstractEntity
{
    [Key]
    public long Id { get; set; }

    public bool IsActive { get; set; } = true;

    protected AbstractEntity()
    {

    }

}
