namespace HotelPMS.Application.DTOs;

public class NightAuditSummaryDto
{
    public DateTime BusinessDate { get; set; }
    public int TotalRoomsOccupied { get; set; }
    public int TotalRoomsVacant { get; set; }
    public decimal TotalDailyRevenue { get; set; }
    public decimal TotalTaxCollected { get; set; }
    public int NoShowCount { get; set; }
    public bool IsAuditCompleted { get; set; }
    public string AuditedByStaffId { get; set; } = string.Empty;
}