using System.ComponentModel.DataAnnotations;

namespace Core.Core.Entities.AbstractEntities;

public abstract class AbstractEntity
{
    [Key]
    public long Id { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt {  get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    protected AbstractEntity()
    {

    }
}
