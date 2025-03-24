using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Hotel.GeoLocation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Core.Core.Entities.Hotel
{
    [Table("Hotels", Schema = "CSI")]
    [Index(nameof(Name))] // Index for quick hotel name lookups
    [Index(nameof(City))] // Index for searching hotels by city
    [Index(nameof(Stars))] // Index for filtering by rating
    [Index(nameof(LanguageCode))] // Optimized for multi-language support
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

        public virtual Location? Location { get; set; } 

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
