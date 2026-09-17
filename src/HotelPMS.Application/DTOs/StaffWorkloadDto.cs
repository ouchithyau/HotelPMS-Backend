namespace HotelPMS.Application.DTOs;

public class StaffWorkloadDto
{
    public string StaffId { get; set; } = string.Empty;
    public string StaffName { get; set; } = string.Empty;
    public int AssignedRoomsCount { get; set; }
    public int CompletedRoomsCount { get; set; }
    public double AverageTurnaroundMinutes { get; set; }
    public string ShiftName { get; set; } = string.Empty; // e.g., "Morning Shift"
}