namespace HotelPMS.Application.DTOs;

public class ActiveStayDto
{
    public Guid BookingId { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public DateTime CheckInDate { get; set; }
    public DateTime ExpectedCheckOutDate { get; set; }
    public string Status { get; set; } = string.Empty;
}