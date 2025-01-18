using System.ComponentModel.DataAnnotations;

namespace GuestSide.Application.DTOs.Request.Guest;

public class GuestDto
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }


    public byte[]? ProfilePicture { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    [DataType(DataType.Date)]
    public DateTime CheckInDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? CheckOutDate { get; set; }

    public string? AdminNotes { get; set; }

    public long StatusId { get; set; }

    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public string? Preferences { get; set; }

    public long RoomId { get; set; }
    public long LanguageId { get; set; }
}
