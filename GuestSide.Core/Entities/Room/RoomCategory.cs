using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Core.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Room;

[Table("RoomCategories", Schema = "CSI")]
[Index(nameof(Name), IsUnique = true)]
[Index(nameof(IsActive))]
public class RoomCategory : AbstractEntity, IExistable<RoomCategory>
{
    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(255)]
    public string? WhatWillRobotSay { get; set; } = "Welcome! Explore this room category for details.";

    [StringLength(255)]
    public string? Description { get; set; }

    public virtual List<Room>? Rooms { get; set; }

    public RoomCategory() { }

    public RoomCategory(string pattern = "Welcome to {0}, here are more details for you: {1}")
    {
        WhatWillRobotSay = pattern;
    }

    public Expression<Func<RoomCategory, bool>> GetExistencePredicate()
    {
        return roomCategory => roomCategory.Name == Name;
    }
}