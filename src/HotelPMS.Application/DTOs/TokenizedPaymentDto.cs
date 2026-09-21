namespace HotelPMS.Application.DTOs;

public class TokenizedPaymentDto
{
    public Guid ReservationId { get; set; }
    public string PaymentToken { get; set; } = string.Empty; // Token from Stripe / Adyen
    public decimal AmountToCharge { get; set; }
    public string Currency { get; set; } = "USD";
}