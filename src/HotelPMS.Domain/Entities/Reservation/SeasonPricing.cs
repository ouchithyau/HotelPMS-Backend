using HotelPMS.Domain.Common;

namespace HotelPMS.Domain.Entities;

public class SeasonPricing : BaseAuditableEntity
{
    public Guid RoomTypeId { get; set; }
    public RoomType RoomType { get; set; } = null!;
    public string SeasonName { get; set; } = string.Empty; // e.g. "Christmas Peak", "Summer"
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal PriceMultiplier { get; set; } = 1.0m; // e.g. 1.25 for 25% extra
}