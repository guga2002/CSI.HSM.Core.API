using Core.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Core.Core.Entities.Restaurant
{
    [Table("RestaurantItems", Schema = "CSI")]
    [Index(nameof(RestaurantId))]
    [Index(nameof(RestaurantItemCategoryId))] 
    [Index(nameof(IsAvailable))] 
    [Index(nameof(Price))]
    public class RestaurantItem : AbstractEntity
    {
        [StringLength(100)]
        public required string Title { get; set; }

        [Column(TypeName = "nvarchar(max)")] 
        public string? PhotoUrlSerialized { get; set; }

        [NotMapped]
        public List<string> PhotoUrl
        {
            get => PhotoUrlSerialized == null ? new List<string>() : JsonSerializer.Deserialize<List<string>>(PhotoUrlSerialized);
            set => PhotoUrlSerialized = value == null ? null : JsonSerializer.Serialize(value);
        }

        [StringLength(255)] 
        public string? Description { get; set; }

        [StringLength(255)] 
        public string? Allergens { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? IngredientsSerialized { get; set; }

        [NotMapped]
        public List<string>? Ingredients
        {
            get => IngredientsSerialized == null ? new List<string>() : JsonSerializer.Deserialize<List<string>>(IngredientsSerialized);
            set => IngredientsSerialized = value == null ? null : JsonSerializer.Serialize(value);
        }

        [Precision(18, 2)] 
        public decimal? Price { get; set; }

        public bool IsAvailable { get; set; } = true; 

        public int? Calories { get; set; } 

        public int? PreparationTimeMinutes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(RestaurantItemCategory))]
        public long RestaurantItemCategoryId { get; set; }

        public virtual RestaurantItemCategory? RestaurantItemCategory { get; set; } 

        [ForeignKey(nameof(Restaurant))]
        public long RestaurantId { get; set; }

        public virtual Restaurants? Restaurant { get; set; } 

        public virtual List<RestaurantItemToCart>? RestaurantItemToCarts { get; set; } 
    }
}
