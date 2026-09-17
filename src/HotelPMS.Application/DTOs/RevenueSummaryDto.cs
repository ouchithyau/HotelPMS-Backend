namespace HotelPMS.Application.DTOs;

public class RevenueSummaryDto
{
    public DateTime BusinessDate { get; set; }
    public decimal TotalCashRevenue { get; set; }
    public decimal TotalCardRevenue { get; set; }
    public decimal TotalCityLedgerRevenue { get; set; }
    public decimal TotalAdjustments { get; set; }
    public decimal GrandTotalRevenue { get; set; }
    public int TotalTransactionsCount { get; set; }
}