using Core.Application.DTOs.Response.Item;
using Core.Application.DTOs.Response.Notification;
using Core.Core.Entities.Item;
using Core.Core.Entities.Notification;
using Core.Core.Entities.Staff;

namespace Core.Application.DTOs.Response.Staff;

public class StaffResponseDto : AbstractResponse
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }

    public required string Position { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? HireDate { get; set; } = DateTime.UtcNow;

    public decimal? Salary { get; set; }

    public byte[]? ProfilePictureUrl { get; set; }

    public long StaffCategoryId { get; set; }

    public long? SupervisorId { get; set; }

    public string? EmergencyContact { get; set; }

    public string? Bio { get; set; }

    public virtual StaffCategoryResponseDto? StaffCategory { get; set; }

    public virtual StaffResponseDto? Supervisor { get; set; } 

    public virtual List<StafNotificationResponseDto>? StaffNotifications { get; set; }

    public virtual List<StaffIncidentResponseDto>? StaffIncidents { get; set; }

    public virtual List<StaffSentimentResponseDto>? StaffSentiments { get; set; }

    public virtual List<StaffInfoAboutRanOutItemsResponseDto>? StaffRequestForItemStockRenewal { get; set; }
}
