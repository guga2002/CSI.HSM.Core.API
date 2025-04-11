using Domain.Core.Entities.AbstractEntities;
using Domain.Core.Entities.Staff;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities.Item;

[Table("ItemCategoryToStaffCategory", Schema = "CSI")]
[Index(nameof(ItemCategoryId))] // Optimized for joins with ItemCategory
[Index(nameof(StaffCategoryId))] // Optimized for joins with StaffCategory
public class ItemCategoryToStaffCategory : AbstractEntity
{
    [ForeignKey(nameof(ItemCategory))]
    public long ItemCategoryId { get; set; } // Required FK

    public virtual ItemCategory? ItemCategory { get; set; } // Virtual for lazy loading

    [ForeignKey(nameof(StaffCategory))]
    public long? StaffCategoryId { get; set; } // Nullable FK

    public virtual StaffCategory? StaffCategory { get; set; } // Virtual for lazy loading
}