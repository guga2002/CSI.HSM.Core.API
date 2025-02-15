using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Staff;

namespace Core.Core.Entities.Item;

[Table("StaffAboutRanOutItems",Schema = "CSI")]
public class StaffInfoAboutRanOutItems : AbstractEntity //staffis wevri chayris im itemebs rac amowurulia da unda ganaxldes
{
    [ForeignKey(nameof(StaffMember))]
    public long StaffId { get; set; }
    public required IEnumerable<long> ItemIds { get; set; }

    public DateTime RequestTime { get; set; }

    public RefillPriority Priority { get; set; }

    public bool Resolved { get; set; } = false;

    [StringLength(200)]
    public string? Notes { get; set; }

    public virtual Staffs? StaffMember { get; set; }
}

public enum RefillPriority
{
    High,
    Low,
    Medium
}
