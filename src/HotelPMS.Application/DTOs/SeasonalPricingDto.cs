namespace HotelPMS.Application.DTOs;

public class SeasonalPricingDto
{
    public Guid RoomTypeId { get; set; }
    public string SeasonName { get; set; } = string.Empty; // e.g., "Christmas Peak", "Summer Season"
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal PriceMultiplier { get; set; } // e.g., 1.30 for +30% increase
}