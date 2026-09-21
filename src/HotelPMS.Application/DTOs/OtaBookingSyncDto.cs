namespace HotelPMS.Application.DTOs;

public class OtaBookingSyncDto
{
    public string OtaName { get; set; } = string.Empty; // e.g., "Booking.com", "Agoda", "Expedia"
    public string ExternalBookingReference { get; set; } = string.Empty;
    public string GuestFullName { get; set; } = string.Empty;
    public string RoomTypeCode { get; set; } = string.Empty;
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public decimal TotalAmount { get; set; }
}