using Domain.Core.Entities.AbstractEntities;
using Domain.Core.Entities.Restaurant;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities.Payment;

[Table("RestaurantOrderPayments", Schema = "CSI")]
[Index(nameof(RestaurantCartId))]
[Index(nameof(PaymentOptionId))]
[Index(nameof(Date))]
public class RestaurantOrderPayment : AbstractEntity
{
    public decimal Total { get; set; }

    public decimal? Discount { get; set; }

    public decimal? TaxAmount { get; set; }

    [NotMapped]
    public decimal FinalTotal => Total - (Discount ?? 0) + (TaxAmount ?? 0);

    [Column("Time_Of_Payment")]
    public DateTime? Date { get; set; }

    [ForeignKey(nameof(PaymentOption))]
    public long PaymentOptionId { get; set; }

    public virtual PaymentOption PaymentOption { get; set; }

    [ForeignKey(nameof(RestaurantCart))]
    public long RestaurantCartId { get; set; }

    public virtual RestaurantCart RestaurantCart { get; set; }

    [StringLength(3)]
    public string? CurrencyCode { get; set; } = "USD"; // Stores transaction currency (ISO 4217 format)

    public bool IsRefunded { get; set; } = false;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}