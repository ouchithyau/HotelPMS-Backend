namespace HotelPMS.Application.DTOs;

public class RoomAvailabilityDto
{
    public string RoomTypeName { get; set; } = string.Empty; // e.g., "Deluxe Ocean View"
    public int TotalRoomsCount { get; set; }
    public int OccupiedRoomsCount { get; set; }
    public int OutOfOrderRoomsCount { get; set; }
    public int AvailableRoomsCount { get; set; }
    public decimal BasePrice { get; set; }
}