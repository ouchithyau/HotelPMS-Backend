namespace HotelPMS.Application.DTOs;

public class OccupancyRuleDto
{
    public Guid RoomTypeId { get; set; }
    public int MaxAdults { get; set; } = 2;
    public int MaxChildren { get; set; } = 1;
    public bool AllowExtraBed { get; set; } = true;
    public decimal ExtraBedCharge { get; set; } = 50.00m;
}