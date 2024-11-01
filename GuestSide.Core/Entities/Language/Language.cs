using GuestSide.Core.Entities.Translations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Language
{
    [Table("Languages", Schema = "CSI")]
    public class Language
    {
        [Key]
        public long Id { get; set; }   
        public required string Code { get; set; }
        public required string Name { get; set; }  
        public IEnumerable<TranslationDictionary> Translations { get; set; } = new List<TranslationDictionary>();
        public IEnumerable<Audio.AudioResponse> AudioResponses { get; set; } = new List<Audio.AudioResponse>();
    }
}
