using Domain.Core.Entities.AbstractEntities;
using Domain.Core.Entities.Guest;
using Domain.Core.Entities.Payment;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities.Restaurant;

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
    public decimal FinalTotal => Subtotal - (Discount ?? 0) + (TaxAmount ?? 0);

    [StringLength(3)]
    public string CurrencyCode { get; set; } = "USD";

    public bool IsPaid { get; set; } = false;

    public virtual List<RestaurantItemToCart>? RestaurantItemToCarts { get; set; }

    public virtual RestaurantOrderPayment? RestaurantOrderPayment { get; set; }
}
