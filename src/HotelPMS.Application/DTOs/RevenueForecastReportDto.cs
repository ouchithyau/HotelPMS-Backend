namespace HotelPMS.Application.DTOs;

public class RevenueForecastReportDto
{
    public DateTime ForecastMonth { get; set; }
    public decimal OccupancyPercentage { get; set; } // e.g., 85.5%
    public decimal AverageDailyRate { get; set; } // ADR
    public decimal RevenuePerAvailableRoom { get; set; } // RevPAR
    public decimal ProjectedTotalRevenue { get; set; }
}