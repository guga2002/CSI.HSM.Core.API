using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Item;

[Table("ItemCategories", Schema = "CSI")]
[Index(nameof(Name))] // Optimized for fast lookups
public class ItemCategory : AbstractEntity, IExistable<ItemCategory>
{
    [Column("CategoryName")]
    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(255)] // Increased length for better text storage
    public string? WhatWillRobotSay { get; set; } = "Explore products, see details, and order items!";

    [StringLength(255)]
    public string? Description { get; set; }

    public virtual List<Items> Items { get; set; } = new(); // Proper ORM handling

    public virtual ItemCategoryToStaffCategory? ItemCategoryToStaffCategory { get; set; } // Virtual for lazy loading

    public ItemCategory() { }

    public ItemCategory(string robotWords = "Your choice is {0}. Explore products, see details, and order items!")
    {
        WhatWillRobotSay = robotWords;
    }

    public Expression<Func<ItemCategory, bool>> GetExistencePredicate()
    {
        return itemcategory => itemcategory.Name == Name;
    }
}