using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.Language;

namespace GuestSide.Core.Entities.Translations
{
    [Table("TranslationDictionaries", Schema = "CSI")]
    public class TranslationDictionary
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Language")]
        public long LanguageId { get; set; } 
        public  required string TranslatedText { get; set; }
        [ForeignKey("BaseDictionary")]
        public long BaseDictionaryId { get; set; }
        public BaseDictionary? BaseDictionary { get; set; }
        public GuestSide.Core.Entities.Language.Language? Language { get; set; }
    }
}
