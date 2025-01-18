namespace Core.Application.DTOs.Response.Payment;

public class PaymentOptionResponseDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
}
