using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.AbstractEntities;

[Index(nameof(CreatedAt))]
[Index(nameof(IsActive))]
[Index(nameof(LanguageCode))]
public abstract class AbstractEntity
{
    [Key]
    public long Id { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt {  get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [StringLength(10)]
    public string? LanguageCode { get; set; }

    protected AbstractEntity()
    {

    }
}
