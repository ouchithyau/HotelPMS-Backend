namespace HotelPMS.Application.DTOs;

public class RoomAmenityDto
{
    public Guid AmenityId { get; set; }
    public string AmenityName { get; set; } = string.Empty; // e.g., "Balcony", "Bathtub", "Sea View"
    public string Description { get; set; } = string.Empty;
}