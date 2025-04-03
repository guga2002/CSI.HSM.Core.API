using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Item;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Staff;

[Table("StaffCategories", Schema = "CSI")]
[Index(nameof(CategoryName), IsUnique = true)]
[Index(nameof(IsActive))]
[Index(nameof(CreatedAt))]
public class StaffCategory : AbstractEntity, IExistable<StaffCategory>
{
    [StringLength(100)]
    public required string CategoryName { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public virtual List<Staffs>? Staff { get; set; }

    public virtual List<TaskToStaff>? TaskToStaff { get; set; }

    public virtual List<ItemCategoryToStaffCategory>? ItemCategoryToStaff { get; set; }

    public Expression<Func<StaffCategory, bool>> GetExistencePredicate()
    {
        return staffCategory => staffCategory.CategoryName == CategoryName;
    }
}