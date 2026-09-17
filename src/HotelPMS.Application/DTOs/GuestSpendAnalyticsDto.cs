namespace HotelPMS.Application.DTOs;

public class GuestSpendAnalyticsDto
{
    public Guid GuestId { get; set; }
    public string GuestFullName { get; set; } = string.Empty;
    public int TotalStays { get; set; }
    public decimal LifetimeSpend { get; set; }
    public decimal AverageSpendPerStay { get; set; }
    public string TopConsumedService { get; set; } = string.Empty; // e.g., "Spa & Wellness", "Fine Dining"
    public DateTime? LastVisitDate { get; set; }
}