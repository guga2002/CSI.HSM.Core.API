using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Guest;
using Core.Core.Entities.Payment;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Restaurant
{
    [Table("RestaurantCarts", Schema = "CSI")]
    [Index(nameof(IsPaid))] 
    [Index(nameof(CreatedAt))] 
    public class RestaurantCart : AbstractEntity
    {
        [ForeignKey(nameof(Guest))]
        public long GuestId { get; set; }

        public virtual Guests? Guest { get; set; } 

        [StringLength(255)]
        public string? WhatWillRobotSay { get; set; } = "Your cart is ready for checkout!";

        [Precision(18, 2)]
        public decimal Subtotal { get; set; } = 0; 

        [Precision(18, 2)]
        public decimal? Discount { get; set; } = 0;

        [Precision(18, 2)]
        public decimal? TaxAmount { get; set; } = 0; 

        [Precision(18, 2)]
        public decimal FinalTotal => (Subtotal - (Discount ?? 0)) + (TaxAmount ?? 0); 

        [StringLength(3)]
        public string CurrencyCode { get; set; } = "USD"; 

        public bool IsPaid { get; set; } = false; 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; 

        public virtual List<RestaurantItemToCart>? RestaurantItemToCarts { get; set; } 

        public virtual RestaurantOrderPayment? RestaurantOrderPayment { get; set; } 
    }
}
