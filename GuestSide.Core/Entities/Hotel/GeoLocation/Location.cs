using GuestSide.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Hotel.GeoLocation
{
    [Table("Locations",Schema ="CSI")]
    public class Location:AbstractEntity
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [ForeignKey(nameof(Hotel))]
        public long HotelId { get; set; }

        public Hotel Hotel { get; set; }
    }
}
