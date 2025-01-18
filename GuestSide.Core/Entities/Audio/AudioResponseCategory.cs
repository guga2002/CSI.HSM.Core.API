using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Audio;

[Table("AudioResponseCategories", Schema = "CSI")]
public class AudioResponseCategory
{
    [Key]
    public long Id { get; set; } 
    public required string CategoryName { get; set; } 
    public string? Description { get; set; } 
    public virtual IEnumerable<AudioResponse> AudioResponses { get; set; }
}
