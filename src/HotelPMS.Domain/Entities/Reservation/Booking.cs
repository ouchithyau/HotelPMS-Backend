using HotelPMS.Domain.Common;
using HotelPMS.Domain.Enums;

namespace HotelPMS.Domain.Entities;

public class Booking : BaseAuditableEntity
{
    public string BookingReference { get; set; } = string.Empty;
    public Guid GuestId { get; set; }
    public Guest Guest { get; set; } = null!;

    public Guid RoomId { get; set; }
    public Room Room { get; set; } = null!;

    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
    public decimal TotalAmount { get; set; }

    public BookingStatus BookingStatus { get; set; } = BookingStatus.Pending;
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

    public ICollection<BookingService> BookingServices { get; set; } = new List<BookingService>();
}