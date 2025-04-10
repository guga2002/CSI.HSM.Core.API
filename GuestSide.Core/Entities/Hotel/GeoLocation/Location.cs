using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Hotel.GeoLocation;

[Table("Locations", Schema = "CSI")]
[Index(nameof(Latitude), nameof(Longitude))] // Optimized for geospatial lookups
public class Location : AbstractEntity, IExistable<Location>
{
    [StringLength(255)] // Increased length for better storage of addresses
    public string? Address { get; set; } // Human-friendly name

    [StringLength(100)]
    public string? City { get; set; }

    public string? MapUrl { get; set; } // Backend will generate a tracking link

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public virtual Hotel Hotel { get; set; } // Virtual for lazy loading

    public Expression<Func<Location, bool>> GetExistencePredicate()
    {
        return l => l.Latitude == Latitude && l.Longitude == Longitude;
    }
}