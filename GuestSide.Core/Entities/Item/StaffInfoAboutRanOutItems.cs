using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;
using Domain.Core.Entities.Enums;
using Domain.Core.Entities.Staff;
using Microsoft.EntityFrameworkCore;

namespace Domain.Core.Entities.Item;

[Table("StaffAboutRanOutItems", Schema = "CSI")]
[Index(nameof(StaffId))]
[Index(nameof(Resolved))]
[Index(nameof(Priority))]
public class StaffInfoAboutRanOutItems : AbstractEntity
{
    [ForeignKey(nameof(StaffMember))]
    public long? StaffId { get; set; }

    public virtual Staffs? StaffMember { get; set; } // Virtual for lazy loading

    [Column(TypeName = "nvarchar(max)")] // Stores JSON-formatted string in the database
    public string? ItemIdsSerialized { get; set; }

    [NotMapped]
    public List<long> ItemIds
    {
        get => ItemIdsSerialized == null ? new List<long>() : System.Text.Json.JsonSerializer.Deserialize<List<long>>(ItemIdsSerialized);
        set => ItemIdsSerialized = value == null ? null : System.Text.Json.JsonSerializer.Serialize(value);
    }

    public DateTime RequestTime { get; set; } = DateTime.UtcNow;

    public PriorityEnum Priority { get; set; }

    public bool Resolved { get; set; } = false;

    [StringLength(200)]
    public string? Notes { get; set; }

    public DateTime? HandledDate { get; set; }

    [NotMapped]
    public bool IsUrgent => Priority == PriorityEnum.High;
}

