namespace HotelPMS.Application.DTOs;

public class PosChargeSyncDto
{
    public Guid ReservationId { get; set; }
    public string OutletName { get; set; } = string.Empty; // e.g., "Main Restaurant", "Ayurveda Spa", "Laundry Service"
    public string ItemDescription { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string StaffId { get; set; } = string.Empty;
}