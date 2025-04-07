using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Hotel.GeoLocation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Text.Json;

namespace Core.Core.Entities.Hotel;

[Table("Hotels", Schema = "CSI")]
public class Hotel : AbstractEntity, IExistable<Hotel>
{
    [StringLength(100)]
    public required string Name { get; set; }

    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow; // Ensures consistent timestamping

    public int Stars { get; set; }

    [StringLength(1000)] // Increased for longer descriptions
    public string? Description { get; set; }

    [ForeignKey("Location")]
    public long LocationId { get; set; }

    public  Location? Location { get; set; } 

    public virtual List<Room.Room>? Rooms { get; set; }

    public string? PicturesSerialized { get; set; }

    public string? FacilitiesSerialized { get; set; }

    [NotMapped]
    public List<string>? Pictures
    {
        get => PicturesSerialized == null ? new List<string>() : JsonSerializer.Deserialize<List<string>>(PicturesSerialized);
        set => PicturesSerialized = value == null ? null : JsonSerializer.Serialize(value);
    }

    [NotMapped]
    public List<string>? Facilities
    {
        get => FacilitiesSerialized == null ? new List<string>() : JsonSerializer.Deserialize<List<string>>(FacilitiesSerialized);
        set => FacilitiesSerialized = value == null ? null : JsonSerializer.Serialize(value);
    }

    public Expression<Func<Hotel, bool>> GetExistencePredicate()
    {
        return i => i.LocationId == LocationId && i.Name == Name;
    }
}
