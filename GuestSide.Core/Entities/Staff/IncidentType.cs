using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Core.Core.Entities.AbstractEntities;

namespace Core.Core.Entities.Staff;

[Table("IncidentTypes",Schema ="CSI")]
public class IncidentType : AbstractEntity, IExistable<IncidentType>
{
    public required string Type { get; set; }

    public string? Description { get; set; }

    public virtual List<StaffIncident>? Incidents { get; set; }

    public virtual List<IncidentTypeToStaffCategory>? IncidentTypeToStaffCategories { get; set; }

    public Expression<Func<IncidentType, bool>> GetExistencePredicate()
    {
        return incidentType => incidentType.Type == Type;
    }
}
