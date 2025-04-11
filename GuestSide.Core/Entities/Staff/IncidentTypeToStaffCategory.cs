using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Staff;

[Table("IncidentTypeToStaffCategories", Schema = "CSI")]
public class IncidentTypeToStaffCategory : AbstractEntity, IExistable<IncidentTypeToStaffCategory>
{
    [ForeignKey(nameof(Category))]
    public long StaffCategoryId { get; set; }

    public virtual StaffCategory? Category { get; set; }

    [ForeignKey(nameof(IncidentType))]
    public long IncidentTypeId { get; set; }

    public virtual IncidentType? IncidentType { get; set; }

    public Expression<Func<IncidentTypeToStaffCategory, bool>> GetExistencePredicate()
    {
        return i => i.StaffCategoryId == StaffCategoryId && i.IncidentTypeId == IncidentTypeId;
    }
}
