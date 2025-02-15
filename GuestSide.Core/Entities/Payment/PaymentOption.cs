using Core.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Payment;

[Table("PaymentOptions", Schema = "CSI")]
public class PaymentOption: AbstractEntity
{
    [Column("Payment_Method_Name")]
    [StringLength(100)]
    public required string Name { get; set; }
    [StringLength(100)]
    public string? LanguageCode { get; set; }

    public virtual IEnumerable<RestaurantOrderPayment>? RestaurantOrderPayments { get; set; }

    public DateTime CreatedDate {  get; set; }
}
