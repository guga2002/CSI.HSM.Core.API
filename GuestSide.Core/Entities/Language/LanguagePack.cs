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
  
        public IEnumerable<Cart> Carts { get; set; }
        public IEnumerable<ItemCategory> ItemCategories { get; set; }
        public IEnumerable<Items> Items { get; set; }
        public IEnumerable<Hotel.Hotel> Hotels { get; set; }
    }
}
