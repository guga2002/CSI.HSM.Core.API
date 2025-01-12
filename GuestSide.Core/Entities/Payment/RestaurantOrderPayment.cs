using Core.Core.Entities.Payment;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Restaurant;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Payment;

[Table("RestaurantOrderPayments", Schema = "CSI")]
public class RestaurantOrderPayment : AbstractEntity
{
    public decimal Total { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Subtotal { get; set; }

    [Column("Time_Of_Payment")]
    public DateTime? Date { get; set; }

    [ForeignKey(nameof(PaymentOption))]
    public long PaymentOptionId {  get; set; }

    [ForeignKey(nameof(RestaurantCart))]
    public long RestaurantCartId { get; set; }

    public virtual RestaurantCart RestaurantCart { get; set; }
    public virtual PaymentOption PaymentOption { get; set; }

}
