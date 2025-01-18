using GuestSide.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Hotel.GeoLocation;

[Table("Locations",Schema ="CSI")]
public class Location:AbstractEntity
{
    public string? Address { get; set; }//human friendly name

    public string? MapUrl { get; set; } //back will generate  link for open  google map  for tracking

    public double Latitude { get; set; }

    public double Longitude { get; set; }


    [ForeignKey(nameof(Hotel))]
    public long HotelId { get; set; }

    public Hotel Hotel { get; set; }
}
