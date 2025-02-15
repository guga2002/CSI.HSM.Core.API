using Core.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Restaurant;

[Table("Restaurants", Schema = "CSI")]
public class Restaurants : AbstractEntity
{
    [StringLength(100)]
    public required string Name { get; set; }
    [StringLength(100)]
    public string? RestaunrantCategory { get; set; } //romeli qveynis samzareuloa
    public IEnumerable<RestaunrantItem>? Items { get; set; }
}
