using Core.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Payment;

[Table("PaymentOptions", Schema = "CSI")]
[Index(nameof(Name), IsUnique = true)] 
[Index(nameof(LanguageCode))] 
[Index(nameof(CreatedDate))] 
public class PaymentOption : AbstractEntity
{
    [Column("Payment_Method_Name")]
    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(10)] 
    public string? LanguageCode { get; set; }

    [StringLength(50)]
    public string? PaymentType { get; set; } // Categorizes payment methods (e.g., "Credit Card", "Mobile Payment")

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow; 

    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow; 

    public virtual List<RestaurantOrderPayment>? RestaurantOrderPayments { get; set; }
}