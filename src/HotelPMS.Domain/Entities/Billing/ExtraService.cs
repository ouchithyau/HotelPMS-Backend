using HotelPMS.Domain.Common;

namespace HotelPMS.Domain.Entities;

public class ExtraService : BaseAuditableEntity
{
    public string ServiceName { get; set; } = string.Empty; // Laundry, MiniBar, Airport Pickup
    public decimal UnitPrice { get; set; }
    public ICollection<BookingService> BookingServices { get; set; } = new List<BookingService>();
}