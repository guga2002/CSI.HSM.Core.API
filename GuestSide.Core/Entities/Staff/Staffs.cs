using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Item;
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

    [StringLength(50)]
    public required string Position { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    [DataType(DataType.Date)]
    public DateTime? HireDate { get; set; }

    [StringLength(150)]
    public string? ProfilePictureUrl { get; set; }

    [ForeignKey(nameof(StaffCategory))]
    public long StaffCategoryId { get; set; }

    [StringLength(200)]
    public string? EmergencyContact { get; set; }

    [StringLength(200)]
    public string? Bio { get; set; }

    public virtual StaffCategory? StaffCategory { get; set; }

    public virtual IEnumerable<StaffNotification>? StaffNotifications { get; set; }

    public virtual IEnumerable<StaffIncident>? StaffIncidents {get;set;}

    public virtual IEnumerable<StaffSentiment>? StaffSentiments { get; set; }

    public virtual IEnumerable<StaffInfoAboutRanOutItems>? StaffRequestForItemStockRenewal { get; set; }

    public virtual IEnumerable<StaffReserveItem>? StaffReservedItems { get; set; }
}
