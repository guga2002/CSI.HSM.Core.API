using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Language;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Item;

[Table("ItemCategories", Schema = "CSI")]
public class ItemCategory:AbstractEntity
{
    [Column("CategoryName")]
    public required string Name { get; set; }
    public string? WhatWillRobotSay { get; set; }
    public string? Description { get; set; }
    [ForeignKey(nameof(language))]
    public long LanguageId { get; set; }
    public virtual LanguagePack? language { get; set; }
    public IEnumerable<Items>? Item { get; set; }
    public ItemCategory(string RobbotWords= "you choice is {0}, explore products, se  details, if  you would  like also  order  items")
    {
        WhatWillRobotSay = string.Format(RobbotWords,Name);
    }
    public ItemCategory()
    {
        
    }
}
