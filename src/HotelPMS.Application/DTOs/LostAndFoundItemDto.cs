namespace HotelPMS.Application.DTOs;

public class LostAndFoundItemDto
{
    public Guid Id { get; set; }
    public Guid RoomId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string FoundByStaffId { get; set; } = string.Empty;
    public DateTime FoundDate { get; set; }
    public string StorageLocation { get; set; } = string.Empty; // e.g., "Safe Box 04"
    public string Status { get; set; } = "Stored"; // "Stored", "Claimed", "Disposed"
}