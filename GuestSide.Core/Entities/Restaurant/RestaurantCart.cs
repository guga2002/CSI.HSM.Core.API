using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Guest;
using Core.Core.Entities.Payment;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Restaurant;

[Table("RestaurantCarts", Schema = "CSI")]
public class RestaurantCart : AbstractEntity
{
    [ForeignKey(nameof(Guests))]
    public long GuestId { get; set; }
    [StringLength(100)]
    public string? WhatWillRobotSay { get; set; }
    public decimal Total => RestaurantItemToCarts?.Sum(item => item?.RestaunrantItem?.Price * item?.Quantity) ?? 0;
    public virtual RestaurantOrderPayment? RestaurantOrderPayment { get; set; }
    public virtual Guests? Guests { get; set; }
    public virtual IEnumerable<RestaurantItemToCart>? RestaurantItemToCarts { get; set; }
}
