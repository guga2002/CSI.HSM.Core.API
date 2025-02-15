using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Hotel.GeoLocation;
using Core.Core.Entities.Language;
using Core.Core.Entities.Room;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Hotel;

[Table("Hotels", Schema = "CSI")]
public class Hotel : AbstractEntity
{
    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(100)]
    public string? Address { get; set; }

    public DateTime RegistrationDate { get; set; }

    public int Stars { get; set; }


    public List<string>? Pictures { get; set; }//linkebi

    [StringLength(100)]
    public string? Description { get; set; }

    [StringLength(100)]
    public IEnumerable<string>? Facilities { get; set; }

    [NotMapped]
    public int TotalRoomCount => Rooms?.Count() ?? 0;

    [StringLength(100)]
    public string? LanguageCode { get; set; }

    public virtual Location? Location { get; set; }

    public virtual IEnumerable<Rooms>? Rooms { get; set; }
}
