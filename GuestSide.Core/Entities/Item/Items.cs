using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Language;
using GuestSide.Core.Entities.Task;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Item
{
    [Table("Items", Schema = "CSI")]
    [Index(nameof(LanguageId))]
    public class Items:AbstractEntity
    {
        [Column("ItemName")]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public string?  Information { get; set; }

        public string? WhatWillRobotSay { get; set; }

        [ForeignKey(nameof(ItemCategory))]
        public long ItemCategoryId {  get; set; }

        [ForeignKey(nameof(language))]
        public long LanguageId { get; set; }
        public virtual LanguagePack? language { get; set; }

        public virtual ItemCategory? ItemCategory { get; set; }


        public Items(string WhatwillRobotSay= "you choice is {0},see details  and more information about this item, happy weekends")
        {
            WhatWillRobotSay = string.Format(WhatwillRobotSay,Name);
        }

    }
}
