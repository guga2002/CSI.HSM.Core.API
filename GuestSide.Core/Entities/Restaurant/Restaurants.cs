using GuestSide.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Restaurant;

[Table("Restaurants", Schema = "CSI")]
public class Restaurants:AbstractEntity
{
    public required string Name { get; set; }
    public string? RestaunrantCategory { get; set; } //romeli qveynis samzareuloa
    public IEnumerable<RestaunrantItem>? Items { get; set; }
}
