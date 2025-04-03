using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Core.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Item;

[Table("Items", Schema = "CSI")]
[Index(nameof(ItemCategoryId))]
[Index(nameof(LanguageCode))]
[Index(nameof(IsOrderAble))]
public class Items : AbstractEntity, IExistable<Items>
{
    [Column("ItemName")]
    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(255)] // Increased for better descriptions
    public string? Description { get; set; }

    [StringLength(255)]
    public string? Information { get; set; }

    public bool IsOrderAble { get; set; }

    [Precision(18, 2)] // Ensuring consistent decimal precision
    public decimal? Price { get; set; }

    [StringLength(255)]
    public string? WhatWillRobotSay { get; set; } = "See details and more information about this item!";

    [ForeignKey(nameof(ItemCategory))]
    public long ItemCategoryId { get; set; }

    public virtual ItemCategory? ItemCategory { get; set; } // Virtual for lazy loading

    [StringLength(10)] // Optimized for storing language codes
    public string? LanguageCode { get; set; }

    public virtual List<TaskItem> TaskItems { get; set; } = new(); // Proper ORM handling

    public DateTime AddedDate { get; set; } = DateTime.UtcNow; // Default timestamp for item creation


    public Items() { }

    public Items(string whatWillRobotSay = "Your choice is {0}. See details and more information about this item.")
    {
        WhatWillRobotSay = whatWillRobotSay;
    }

    public Expression<Func<Items, bool>> GetExistencePredicate()
    {
        return item => item.Name == Name && item.ItemCategoryId == ItemCategoryId;
    }
}
