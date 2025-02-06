using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Hotel.GeoLocation;
using GuestSide.Core.Entities.Language;
using GuestSide.Core.Entities.Room;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Hotel;

[Table("Hotels", Schema = "CSI")]
public class Hotel:AbstractEntity
{
    public required string Name { get; set; }

    public string?  City { get; set; }

    public string? Address { get; set; }

    public DateTime RegistrationDate { get; set; }

    public int Stars { get; set; }

    public bool IsActive { get; set; } = true;

    public List<string>? Pictures { get; set; }//linkebi

    public string? Description { get; set; }

    public   IEnumerable<string>? Facilities { get; set; }

    [NotMapped]
    public int TotalRoomCount => Rooms?.Count() ?? 0;

    [ForeignKey(nameof(languagePack))]
    public long LanguageId { get; set; }
    public virtual LanguagePack? languagePack { get; set; }

    public virtual Location? Location { get; set; }

    public virtual IEnumerable<Rooms>? Rooms { get; set; }
}
