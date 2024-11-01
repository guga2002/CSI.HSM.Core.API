using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Translations
{
    [Table("BaseDictionaries",Schema ="CSI")]
    public class BaseDictionary
    {
        [Key]
        public long Id { get; set; }
        public required string GeorgianText { get; set; }

        public IEnumerable<TranslationDictionary> Translations { get; set; } = new List<TranslationDictionary>();
    }
}
