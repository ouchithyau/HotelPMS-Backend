namespace HotelPMS.Application.DTOs;

public class AvailabilityDto
{
    public Guid RoomTypeId { get; set; }
    public string RoomTypeName { get; set; } = string.Empty;
    public int AvailableCount { get; set; }
    public decimal PricePerNight { get; set; }
}