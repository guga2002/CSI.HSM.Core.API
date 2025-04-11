using Domain.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities.Restaurant;

[Table("Restaurants", Schema = "CSI")]
[Index(nameof(Name), IsUnique = true)]
[Index(nameof(RestaurantCategory))]
[Index(nameof(IsActive))]
[Index(nameof(CreatedAt))]
public class Restaurants : AbstractEntity
{
    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(100)]
    public string? RestaurantCategory { get; set; }

    [StringLength(255)]
    public string? Location { get; set; }

    public TimeSpan? OpeningTime { get; set; }

    public TimeSpan? ClosingTime { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public virtual List<RestaurantItem>? Items { get; set; }
}