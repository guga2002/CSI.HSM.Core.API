using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.Item;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Language;
using GuestSide.Core.Entities.Task;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Core.Entities.Item;

[Table("Items", Schema = "CSI")]
[Index(nameof(LanguageId))]
public class Items : AbstractEntity
{
    [Column("ItemName")]
    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? Information { get; set; }

    public bool IsOrderable { get; set; }

    public decimal? Price { get; set; }

    public int Quantity { get; set; } //refer to  quantity of item in stock

    public string? WhatWillRobotSay { get; set; }

    [ForeignKey(nameof(ItemCategory))]
    public long ItemCategoryId { get; set; }
    public virtual ItemCategory? ItemCategory { get; set; }

    [ForeignKey(nameof(LanguagePack))]
    public long LanguageId { get; set; }
    public virtual LanguagePack? LanguagePack { get; set; }

    public virtual ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();

    public Items(string whatWillRobotSay = "Your choice is {0}. See details and more information about this item. Happy weekends!")
    {
        WhatWillRobotSay = string.Format(whatWillRobotSay, Name);
    }

    public Items() { }
}
