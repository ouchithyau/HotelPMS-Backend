namespace HotelPMS.Application.DTOs;

public class RoomStatusBoardDto
{
    public int FloorNumber { get; set; }
    public List<RoomStatusItemDto> Rooms { get; set; } = new();
}

public class RoomStatusItemDto
{
    public Guid RoomId { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public string RoomTypeName { get; set; } = string.Empty;
    public string HousekeepingStatus { get; set; } = string.Empty; // "Clean", "Dirty", "Inspected", "OOO"
    public string FrontOfficeStatus { get; set; } = string.Empty; // "Vacant", "Occupied", "Reserved"
    public string? CurrentGuestName { get; set; }
}