namespace Core.Application.DTOs.Request.Payment;

public class RestaurantOrderPaymentDto
{
    public decimal Total { get; set; }

    public DateTime? Date { get; set; }

    public long PaymentOptionId { get; set; }

    public long RestaurantCartId { get; set; }
}
