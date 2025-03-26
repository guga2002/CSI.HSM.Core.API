﻿using Core.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Hotel.GeoLocation
{
    [Table("Locations", Schema = "CSI")]
    [Index(nameof(Latitude), nameof(Longitude))] // Optimized for geospatial lookups
    public class Location : AbstractEntity
    {
        [StringLength(255)] // Increased length for better storage of addresses
        public string? Address { get; set; } // Human-friendly name

        public string? MapUrl { get; set; } // Backend will generate a tracking link

        public double Latitude { get; set; }

        public double Longitude { get; set; }
        public virtual Hotel Hotel { get; set; } // Virtual for lazy loading
    }
}