using Core.Core.Entities.Language;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Audio;

[Table("AudioResponses", Schema = "CSI")]
public class AudioResponse
{
    [Key]
    public long Id { get; set; }
    [StringLength(100)]
    public required string TextContent { get; set; }

    [ForeignKey(nameof(Language))]
    public long LanguageId { get; set; }
    [StringLength(100)]
    public string? VoiceType { get; set; }
    [StringLength(100)]
    public required string AudioFilePath { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime CreatedDate { get; set; }

    [ForeignKey("Categories")]
    public long CategoryId { get; set; }
    public virtual AudioResponseCategory? Categories { get; set; }

    [StringLength(100)]
    public LanguagePack Language { get; set; }
}