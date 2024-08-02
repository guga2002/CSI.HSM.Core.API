using GuestSide.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Item
{
    [Table("ItemCategories")]
    public class ItemCategory:AbstractEntity
    {
        [Column("CategoryName")]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public IEnumerable<Item> Item { get; set; }
    }
}
