using Core.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Hotel.GeoLocation
{
    [Table("Locations", Schema = "CSI")]
    [Index(nameof(HotelId))] // Optimized for hotel-location joins
    [Index(nameof(Latitude), nameof(Longitude))] // Optimized for geospatial lookups
    public class Location : AbstractEntity
    {
        [StringLength(255)] // Increased length for better storage of addresses
        public string? Address { get; set; } // Human-friendly name

        [Column(TypeName = "nvarchar(max)")] // Supports long dynamic map URLs
        public string? MapUrl { get; set; } // Backend will generate a tracking link

        [Column(TypeName = "double(9,6)")] // Optimized precision for geo-coordinates
        public double Latitude { get; set; }

        [Column(TypeName = "double(9,6)")]
        public double Longitude { get; set; }

        [ForeignKey(nameof(Hotel))]
        public long HotelId { get; set; }

        public virtual Hotel Hotel { get; set; } // Virtual for lazy loading
    }
}