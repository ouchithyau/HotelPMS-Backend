using HotelPMS.Domain.Common;

namespace HotelPMS.Domain.Entities.Reservation;

public class Reservation : BaseAuditableEntity
{
    public Guid GuestId { get; set; }
    public Guid RoomId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Confirmed"; // Confirmed, CheckedIn, CheckedOut, Cancelled, NoShow

    // --- Phase 1: Special Requests & Preferences ---
    public string? SpecialRequests { get; set; } // e.g., High floor, Honeymoon setup
    public bool IsGroupBooking { get; set; } = false;
    public string? GroupCode { get; set; }
}