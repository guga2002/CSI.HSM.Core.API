using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Notification;

namespace Core.Core.Entities.Staff;

[Table("Staffs", Schema = "CSI")]
public class Staffs : AbstractEntity
{
    [StringLength(100)]
    public required string FirstName { get; set; }

    [StringLength(100)]
    public required string LastName { get; set; }

    [StringLength(100)]
    public required string Email { get; set; }

    [StringLength(100)]
    public required string PhoneNumber { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    [DataType(DataType.Date)]
    public DateTime? HireDate { get; set; }

    [ForeignKey(nameof(StaffCategory))]
    public long StaffCategoryId { get; set; }

    public virtual StaffCategory? StaffCategory { get; set; }

    public virtual IEnumerable<StaffNotification>? StaffNotifications { get; set; }
}
