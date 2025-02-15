using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Staff;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Item;

[Table("ItemCategoryToStaffCategory",Schema = "CSI")]
public class ItemCategoryToStaffCategory: AbstractEntity
{
    [ForeignKey(nameof(ItemCategory))]
    public long ItemCategoryId {  get; set; }
    public ItemCategory? ItemCategory { get; set; }

    [ForeignKey(nameof(StaffCategory))]
    public long? StaffCategoryId { get; set; }
    public StaffCategory? StaffCategory { get; set; }
}
