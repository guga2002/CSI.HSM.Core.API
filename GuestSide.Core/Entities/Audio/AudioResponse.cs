using GuestSide.Core.Entities.Language;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Audio
{
    [Table("AudioResponses", Schema = "CSI")]
    public class AudioResponse
    {
        [Key]
        public long Id { get; set; }  
        public required string TextContent { get; set; }

        [ForeignKey(nameof(Language))]
        public long LanguageId { get; set; } 
        public string? VoiceType { get; set; } 
        public required string AudioFilePath { get; set; } 
        public TimeSpan Duration { get; set; } 
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Categorie")]
        public long  CategoryId { get; set; }
        public virtual AudioResponseCategory? Categorie { get; set; }

        public LanguagePack Language { get; set; }
    }

}
