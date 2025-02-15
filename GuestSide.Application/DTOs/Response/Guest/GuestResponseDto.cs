using System.ComponentModel.DataAnnotations;
using Core.Application.DTOs.Response.Room;

namespace Core.Application.DTOs.Response.Guest;

public class GuestResponseDto
{
    public long Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }


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

    public bool IsFrequentGuest { get; set; }

    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public long RoomId { get; set; }

    public string? Preferences { get; set; }

    public long LanguageId { get; set; }

    public virtual RoomsResponseDto? Room { get; set; }
}
