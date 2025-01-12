using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Payment;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Payment;

[Table("PaymentOptions", Schema = "CSI")]
public class PaymentOption: AbstractEntity
{
    [Column("Payment_Method_Name")]
    public required string Name { get; set; }

    public virtual IEnumerable<RestaurantOrderPayment>? RestaurantOrderPayments { get; set; }

    public bool IsActive {  get; set; }

    public DateTime CreatedDate {  get; set; }
}
