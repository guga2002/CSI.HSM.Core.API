using Core.Core.Entities.Restaurant;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Entities.Payment;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Restaurant;

[Table("RestaurantCarts", Schema = "CSI")]
public class RestaurantCart : AbstractEntity
{
    [ForeignKey(nameof(Guests))]
    public long GuestId { get; set; }
    public string? WhatWillRobotSay { get; set; }
    public decimal Total => RestaurantItemToCarts?.Sum(item => item?.RestaunrantItem?.Price * item?.Quantity) ?? 0;
    public virtual RestaurantOrderPayment? RestaurantOrderPayment { get; set; }
    public virtual Guests? Guests { get; set; }
    public virtual IEnumerable<RestaurantItemToCart>? RestaurantItemToCarts { get; set; }
}
