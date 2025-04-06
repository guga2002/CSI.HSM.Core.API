using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Guest;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Linq.Expressions;

namespace Core.Core.Entities.Room;

[Table("Rooms", Schema = "CSI")]
[Index(nameof(RoomNumber))]
[Index(nameof(Floor))]
[Index(nameof(RoomCategoryId))]
[Index(nameof(IsAvailable))]
[Index(nameof(CreatedAt))]
public class Room : AbstractEntity, IExistable<Room>
{
    public int RoomNumber { get; set; }

    public int Floor { get; set; }

    [StringLength(255)]
    public string? WhatWillRobotSay { get; set; } = "Welcome to your room!";

    public bool IsAvailable { get; set; } = true;

    public int MaxOccupancy { get; set; } = 2;

    [Precision(18, 2)]
    public decimal PricePerNight { get; set; } = 100;

    [Column(TypeName = "nvarchar(max)")]
    public string? PictureUrlsSerialized { get; set; }

    [NotMapped]
    public List<string>? Pictures
    {
        get => PictureUrlsSerialized == null ? new List<string>() : JsonSerializer.Deserialize<List<string>>(PictureUrlsSerialized);
        set => PictureUrlsSerialized = value == null ? null : JsonSerializer.Serialize(value);
    }

    [ForeignKey(nameof(RoomCategory))]
    public long RoomCategoryId { get; set; }

    public virtual RoomCategory? RoomCategory { get; set; }

    [ForeignKey(nameof(Hotel))]
    public long HotelId { get; set; }

    public virtual Hotel.Hotel? Hotel { get; set; }

    public virtual List<Guests>? Guests { get; set; }

    public virtual QRCode? QRCode { get; set; }

    public Room() { }

    public Room(string pattern = "You are on floor {0}, and your room number is {1}.")
    {
        WhatWillRobotSay = pattern;
    }

    public Expression<Func<Room, bool>> GetExistencePredicate()
    {
        return room => room.RoomNumber == RoomNumber && room.HotelId == HotelId && room.RoomCategoryId == RoomCategoryId && room.Floor == Floor;
    }
}
