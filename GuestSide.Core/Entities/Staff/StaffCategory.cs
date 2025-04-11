using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Domain.Core.Entities.AbstractEntities;
using Domain.Core.Entities.Item;
using Microsoft.EntityFrameworkCore;

namespace Domain.Core.Entities.Staff;

[Table("StaffCategories", Schema = "CSI")]
[Index(nameof(CategoryName), IsUnique = true)]
[Index(nameof(IsActive))]
public class StaffCategory : AbstractEntity, IExistable<StaffCategory>
{
    [StringLength(100)]
    public required string CategoryName { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    public virtual List<Staffs>? Staff { get; set; }

    public virtual List<TaskToStaff>? TaskToStaff { get; set; }

    public virtual List<ItemCategoryToStaffCategory>? ItemCategoryToStaff { get; set; }

    public virtual List<IncidentTypeToStaffCategory>? StaffIncidentTypeToStaffCategories { get; set; }

    public Expression<Func<StaffCategory, bool>> GetExistencePredicate()
    {
        return staffCategory => staffCategory.CategoryName == CategoryName;
    }
}