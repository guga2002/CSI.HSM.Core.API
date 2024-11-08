using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Hotel.GeoLocation;
using GuestSide.Core.Entities.Room;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Hotel
{
    [Table("Hotels", Schema = "CSI")]
    public class Hotel:AbstractEntity
    {
        public required string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int Stars { get; set; }

        public string? Description { get; set; }

        public Location Location { get; set; }

        public IEnumerable<Rooms> Rooms { get; set; }
    }
}
