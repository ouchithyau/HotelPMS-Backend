using HotelPMS.Domain.Common;

namespace HotelPMS.Domain.Entities;

public class BookingService : BaseAuditableEntity
{
    public Guid BookingId { get; set; }
    public Booking Booking { get; set; } = null!;

    public Guid ExtraServiceId { get; set; }
    public ExtraService ExtraService { get; set; } = null!;

    public int Quantity { get; set; } = 1;
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime ServiceDate { get; set; } = DateTime.UtcNow;
}