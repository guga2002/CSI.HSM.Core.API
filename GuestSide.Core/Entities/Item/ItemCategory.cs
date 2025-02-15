using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Language;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Item;

[Table("ItemCategories", Schema = "CSI")]
public class ItemCategory : AbstractEntity
{
    [Column("CategoryName")]
    [StringLength(100)]
    public required string Name { get; set; }
    [StringLength(100)]
    public string? WhatWillRobotSay { get; set; }
    [StringLength(100)]
    public string? Description { get; set; }

    [StringLength(100)]
    public string? LanguageCode { get; set; }
    public virtual IEnumerable<Items>? Item { get; set; }
    public virtual ItemCategoryToStaffCategory? ItemCategoryToStaffCategory { get; set; }
    public ItemCategory(string robotWords = "you choice is {0}, explore products, se  details, if  you would  like also  order  items")
    {
        WhatWillRobotSay = string.Format(robotWords, Name);
    }
    public ItemCategory()
    {

    }
}
