using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Hotel.GeoLocation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Core.Core.Entities.Hotel
{
    [Table("Hotels", Schema = "CSI")]
    public class Hotel : AbstractEntity
    {
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(255)] // Extended length for detailed addresses
        public string? Address { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow; // Ensures consistent timestamping

        public int Stars { get; set; }

        [StringLength(1000)] // Increased for longer descriptions
        public string? Description { get; set; }

        [StringLength(10)] // Optimized for storing language codes
        public string? LanguageCode { get; set; }

        [ForeignKey("Location")]
        public long LocationId { get; set; }
        public  Location? Location { get; set; } 

        public virtual List<Room.Room> Rooms { get; set; } = new();

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
    }
}
