using GuestSide.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Item
{
    [Table("Items")]
    public class Item:AbstractEntity
    {
        //Name of the item
        [Column("ItemName")]
        public required string Name { get; set; }

        //Detailed description of the item
        public string? Description { get; set; }

        public decimal? Price { get; set; } = 0;

        [ForeignKey(nameof(ItemCategory))]
        public long ItemCategoryId {  get; set; }

        public ItemCategory ItemCategory { get; set; }
    }
}
