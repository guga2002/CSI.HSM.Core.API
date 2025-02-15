using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Audio;

[Table("AudioResponseCategories", Schema = "CSI")]
public class AudioResponseCategory
{
    [Key]
    public long Id { get; set; }
    [StringLength(100)]
    public required string CategoryName { get; set; }
    [StringLength(100)]
    public string? Description { get; set; }
    public virtual IEnumerable<AudioResponse> AudioResponses { get; set; }
}
