using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Audio;

[Table("AudioResponseCategories", Schema = "CSI")]
[Index(nameof(CategoryName))] 
public class AudioResponseCategory
{
    [Key]
    public long Id { get; set; }

    [StringLength(100)]
    public required string CategoryName { get; set; }

    [StringLength(255)] 
    public string? Description { get; set; }

    public virtual List<AudioResponse>? AudioResponses { get; set; }
}