using Core.Core.Entities.Item;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Language
{
    [Table("LanguagePacks", Schema = "CSI")]
    public class LanguagePack
    {
        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public required string Code { get; set; }
        [StringLength(100)]
        public required string Name { get; set; }
    }
}
