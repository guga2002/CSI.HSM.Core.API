using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;
using Domain.Core.Entities.Item;
using Domain.Core.Entities.Notification;
using Domain.Core.Entities.Restaurant;
using Microsoft.EntityFrameworkCore;

namespace Domain.Core.Entities.Guest;

[Table("Guests", Schema = "CSI")]
[Index(nameof(Email), IsUnique = true)] // Unique index for quick lookups
[Index(nameof(PhoneNumber))] // Helps search guests by phone
[Index(nameof(CheckInDate))] // Optimized for date-range queries
[Index(nameof(CheckOutDate))] // Optimized for departures filtering
public class Guests : AbstractEntity
{
    [StringLength(100)]
    public required string FirstName { get; set; } = "Guest"; // Default value if not provided

    [StringLength(100)]
    public required string LastName { get; set; } = "Gustiashvili"; // Default

    [StringLength(100)]
    [EmailAddress]
    public required string Email { get; set; } = "Guest@csi.com"; // Unique email required

    [StringLength(100)]
    public required string PhoneNumber { get; set; } = "555555555"; // Default phone

    [StringLength(255)]
    public string? WhatWillRobotSay { get; set; }

    public byte[]? ProfilePicture { get; set; } // Optional guest profile picture

    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; } = new DateTime(2002, 02, 20); // Default value

    [StringLength(100)]
    public string? Country { get; set; } = "Georgia"; // Default country

    [StringLength(100)]
    public string? City { get; set; } = "Tbilisi"; // Default city

    [StringLength(255)]
    public string? Address { get; set; } = "Marjanishvilis Avenue N56"; // Default address

    [DataType(DataType.Date)]
    public DateTime CheckInDate { get; set; } = DateTime.UtcNow; // Consistent timestamps

    [DataType(DataType.Date)]
    public DateTime? CheckOutDate { get; set; } // Nullable checkout date

    [StringLength(255)]
    public string? AdminNotes { get; set; }

    [ForeignKey(nameof(Status))]
    public long StatusId { get; set; } // Updates when guest status changes

    public bool IsFrequentGuest { get; set; } = false; // Updated based on history tracking

    [StringLength(100)]
    public string? EmergencyContactName { get; set; } // Optional emergency contact

    [StringLength(100)]
    public string? EmergencyContactPhone { get; set; } // Optional

    [StringLength(255)]
    public string? Preferences { get; set; } // Guest habits/preferences

    [ForeignKey(nameof(Room))]
    public long RoomId { get; set; }
    public bool HasBeenFinalized { get; set; } = false;
    public virtual Room.Room? Room { get; set; } 
    public virtual Status? Status { get; set; } 

    public virtual GuestActiveLanguage ActiveLanguage { get; set; } 

    public virtual List<Cart>? Carts { get; set; }

    public virtual List<GuestNotification> GuestNotifications { get; set; }

    public virtual List<RestaurantCart> RestaurantCart { get; set; }

    public virtual List<GuestIssue>? GuestIssues { get; set; } 

    public Guests(string pattern = "Hi {0} {1}, welcome to our hotel, we are glad to see you here")
    {
        FirstName = "Guest";
        LastName = "Gustiashvili";
        WhatWillRobotSay = string.Format(pattern, FirstName, LastName);
    }

    public Guests() { }
}
