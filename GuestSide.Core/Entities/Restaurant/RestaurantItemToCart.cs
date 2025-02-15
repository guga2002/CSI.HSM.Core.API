using Core.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Restaurant
{
    [Table("RestaurantItemToCarts", Schema = "CSI")]
    [Index(nameof(CreatedAt))] 
    public class RestaurantItemToCart : AbstractEntity
    {
        [ForeignKey(nameof(RestaurantCart))]
        public long RestaurantCartId { get; set; }

        public virtual RestaurantCart? RestaurantCart { get; set; } 

        [ForeignKey(nameof(RestaurantItem))]
        public long RestaurantItemId { get; set; }

        public virtual RestaurantItem? RestaurantItem { get; set; } 

        public int Quantity { get; set; }

        [Precision(18, 2)]
        public decimal UnitPrice { get; set; } 

        [NotMapped]
        public decimal TotalPrice => UnitPrice * Quantity; 

        public bool IsOrdered { get; set; } = false; 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; 
    }
}