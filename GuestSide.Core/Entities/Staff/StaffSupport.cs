using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Core.Core.Entities.Enums;

namespace Core.Core.Entities.Staff;

[Table("StaffSupports", Schema = "CSI")]
[Index(nameof(StaffId))]
[Index(nameof(Priority))] 
[Index(nameof(Status))] 
public class StaffSupport : AbstractEntity
{
    [ForeignKey(nameof(StaffMember))]
    public long StaffId { get; set; }

    public virtual Staffs? StaffMember { get; set; } 

    [StringLength(200)]
    public string? Subject { get; set; } 

    [StringLength(1000)]
    public string? Description { get; set; } 

    [StringLength(100)]
    public string? Category { get; set; } // Categorizes the support request (e.g., "IT", "HR", "Facilities")

    public PriorityEnum Priority { get; set; } = PriorityEnum.Medium; // Default priority

    public StatusEnum Status { get; set; } = StatusEnum.Open; // Default status

    public DateTime? ResolvedDate { get; set; }

    [Column(TypeName = "nvarchar(max)")] 
    public string? AttachmentUrlsSerialized { get; set; }

    [NotMapped]
    public List<string>? AttachmentUrls
    {
        get => AttachmentUrlsSerialized == null ? new List<string>() : JsonSerializer.Deserialize<List<string>>(AttachmentUrlsSerialized);
        set => AttachmentUrlsSerialized = value == null ? null : JsonSerializer.Serialize(value);
    }

    public virtual StaffSupportResponse? SupportResponse { get; set; } // Virtual for lazy loading
}
