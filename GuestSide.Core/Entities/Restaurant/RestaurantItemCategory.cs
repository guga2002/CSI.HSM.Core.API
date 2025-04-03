using Core.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Restaurant;

[Table("RestaurantItemCategories", Schema = "CSI")]
[Index(nameof(CategoryName), IsUnique = true)] 
[Index(nameof(IsActive))] 
[Index(nameof(CreatedAt))] 
public class RestaurantItemCategory : AbstractEntity
{
    [StringLength(100)]
    public required string CategoryName { get; set; }

    [StringLength(255)] 
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true; 

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; 

    public virtual List<RestaurantItem>? RestaurantItems { get; set; }
}