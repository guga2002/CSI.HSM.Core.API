using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Task;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Item
{
    [Table("Items", Schema = "CSI")]
    public class Items:AbstractEntity
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

        public IEnumerable<Tasks> Tasks {  get; set; }

        public byte ItemCount {  get; set; }

    }
}
