using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Core.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Audio;

[Table("AudioResponses", Schema = "CSI")]
[Index(nameof(VoiceType))]
[Index(nameof(CategoryId))]
public class AudioResponse :AbstractEntity, IExistable<AudioResponse>
{

    [StringLength(255)]
    public required string TextContent { get; set; }

    [StringLength(50)]
    public string? VoiceType { get; set; }

    [StringLength(255)]
    public required string AudioFilePath { get; set; }

    public TimeSpan Duration { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(Category))]
    public long CategoryId { get; set; }

    public virtual AudioResponseCategory? Category { get; set; }

    public Expression<Func<AudioResponse, bool>> GetExistencePredicate()
    {
        return i => i.AudioFilePath == AudioFilePath;
    }
}