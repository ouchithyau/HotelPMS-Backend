namespace HotelPMS.Application.DTOs;

public class GuestPreferenceDto
{
    public Guid Id { get; set; }
    public string Category { get; set; } = string.Empty; // e.g., "Room", "Dining", "Pillow"
    public string PreferenceValue { get; set; } = string.Empty; // e.g., "Feather Pillow, High Floor"
    public string Notes { get; set; } = string.Empty;
}