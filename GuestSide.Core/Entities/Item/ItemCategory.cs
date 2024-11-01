using GuestSide.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Item
{
    [Table("ItemCategories", Schema = "CSI")]
    public class ItemCategory:AbstractEntity
    {
        [Column("CategoryName")]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public IEnumerable<Items> Item { get; set; }
    }
}
