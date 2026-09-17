namespace HotelPMS.Application.DTOs;

public class InvoiceDto
{
    public Guid BookingId { get; set; }
    public string BookingReference { get; set; } = string.Empty;
    public string GuestName { get; set; } = string.Empty;
    public string RoomNumber { get; set; } = string.Empty;
    public decimal RoomCharges { get; set; }
    public decimal ExtraServicesTotal { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentStatus { get; set; } = string.Empty;
    public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
    public decimal ExtraServiceCharges { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalBalance { get; set; }
    public bool IsPaid { get; set; }
}