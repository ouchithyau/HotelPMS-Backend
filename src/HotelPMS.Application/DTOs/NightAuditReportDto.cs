namespace HotelPMS.Application.DTOs;

public class NightAuditReportDto
{
    public DateTime AuditDate { get; set; }
    public decimal TotalDailyRevenue { get; set; }
    public int TotalOccupiedRooms { get; set; }
    public double OccupancyRatePercentage { get; set; }
    public int ArrivalsCount { get; set; }
    public int DeparturesCount { get; set; }
}