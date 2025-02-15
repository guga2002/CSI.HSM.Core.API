using System.ComponentModel.DataAnnotations;
using Core.Core.Entities.Guest;
using Core.Core.Entities.Language;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Application.DTOs.Request.Guest;

public class GuestDto
{
    public required string FirstName { get; set; }

    [StringLength(100)]
    public required string LastName { get; set; }

    [StringLength(100)]
    [EmailAddress]
    public required string Email { get; set; }

    [StringLength(100)]
    public required string PhoneNumber { get; set; }


    public byte[]? ProfilePicture { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    [StringLength(100)]
    public string? Country { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(255)]
    public string? Address { get; set; }

    [DataType(DataType.Date)]
    public DateTime CheckInDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? CheckOutDate { get; set; }

    [StringLength(255)]
    public string? AdminNotes { get; set; }

    [ForeignKey(nameof(Status))]
    public long StatusId { get; set; }

    public bool IsFrequentGuest { get; set; } = false;

    [StringLength(100)]
    public string? EmergencyContactName { get; set; }

    [StringLength(100)]
    public string? EmergencyContactPhone { get; set; }

    [StringLength(255)]
    public string? Preferences { get; set; }

    [ForeignKey(nameof(Room))]
    public long RoomId { get; set; }

    [ForeignKey(nameof(LanguagePack))]
    public long LanguageId { get; set; }

}
