namespace HotelPMS.Application.DTOs;

public class BedConfigurationDto
{
    public Guid BedConfigId { get; set; }
    public string BedTypeName { get; set; } = string.Empty; // e.g., "King Size", "Twin Beds", "Queen Size"
    public int QuantityAvailable { get; set; }
}