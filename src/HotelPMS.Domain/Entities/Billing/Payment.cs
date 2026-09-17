using HotelPMS.Domain.Common;

namespace HotelPMS.Domain.Entities.Billing;

public class Payment : BaseAuditableEntity
{
    public Guid BookingId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty; // Cash, Card, Online
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    // Navigation property
    // public Booking Booking { get; set; } = null!;
}