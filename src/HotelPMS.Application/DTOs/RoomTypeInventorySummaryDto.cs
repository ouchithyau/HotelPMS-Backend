namespace HotelPMS.Application.DTOs;

public class RoomTypeInventorySummaryDto
{
    public Guid RoomTypeId { get; set; }
    public string RoomTypeName { get; set; } = string.Empty;
    public int TotalRoomsCount { get; set; }
    public int OutOfOrderRoomsCount { get; set; }
    public int SellableActiveInventory { get; set; }
}