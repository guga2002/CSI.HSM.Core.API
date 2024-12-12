using GuestSide.Core.Entities.Language;
using GuestSide.Core.Entities.Task;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Item
{
    [Table("OrderableItems", Schema = "CSI")]
    public class OrderableItem:AbstractEntities.AbstractEntity
    {
        [Column("ItemName")]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? WhatWillRobotSay { get; set; } 

        public decimal? Price { get; set; } = 0;

        [ForeignKey(nameof(language))]
        public long LanguageId { get; set; }
        public virtual LanguagePack? language { get; set; }

        [ForeignKey(nameof(ItemCategory))]
        public long ItemCategoryId { get; set; }

        public ItemCategory? ItemCategory { get; set; }

        public IEnumerable<Tasks>? Tasks { get; set; }//only orderable item  can  add as  task

        public OrderableItem(string WhatWillRobotSay="You choice is {0}, add it  in cart and will get in time, thank you for choice  you service")
        {
            WhatWillRobotSay = string.Format(WhatWillRobotSay, Name);
        }
    }
}
