using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Item;
using Core.Core.Entities.Notification;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Staff;

[Table("Staffs", Schema = "CSI")]
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(PhoneNumber))]
[Index(nameof(Position))]
[Index(nameof(StaffCategoryId))]
[Index(nameof(HireDate))]
[Index(nameof(IsActive))]
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
    public DateTime? HireDate { get; set; } = DateTime.UtcNow;

    [Precision(18, 2)]
    public decimal? Salary { get; set; }

    [StringLength(150)]
    public string? ProfilePictureUrl { get; set; }

    [ForeignKey(nameof(StaffCategory))]
    public long StaffCategoryId { get; set; }

    [ForeignKey(nameof(Supervisor))]
    public long? SupervisorId { get; set; }

    [StringLength(200)]
    public string? EmergencyContact { get; set; }

    [StringLength(500)]
    public string? Bio { get; set; }

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Tracks last modification time

    public virtual StaffCategory? StaffCategory { get; set; }

    public virtual Staffs? Supervisor { get; set; } // Tracks reporting hierarchy

    public virtual List<StaffNotification>? StaffNotifications { get; set; }

    public virtual List<StaffIncident>? StaffIncidents { get; set; }

    public virtual List<StaffSentiment>? StaffSentiments { get; set; }

    public virtual List<StaffInfoAboutRanOutItems>? StaffRequestForItemStockRenewal { get; set; }
}