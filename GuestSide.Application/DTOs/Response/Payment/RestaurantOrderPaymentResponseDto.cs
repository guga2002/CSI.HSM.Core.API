namespace Core.Application.DTOs.Response.Payment;

public class RestaurantOrderPaymentResponseDto
{
    public long Id { get; set; }

    public decimal Total { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Subtotal { get; set; }

    public DateTime? Date { get; set; }

    public long PaymentOptionId { get; set; }

    public long RestaurantCartId { get; set; }
}
