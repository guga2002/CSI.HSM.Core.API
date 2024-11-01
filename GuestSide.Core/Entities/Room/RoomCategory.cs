using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;

namespace GuestSide.Core.Entities.Room
{
    [Table("RoomCategories", Schema = "CSI")]
    public class RoomCategory:AbstractEntity
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public IEnumerable<Rooms>Rooms { get; set; }
    }
}
