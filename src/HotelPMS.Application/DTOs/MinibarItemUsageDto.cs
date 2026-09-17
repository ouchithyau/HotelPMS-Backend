namespace HotelPMS.Application.DTOs;

public class MinibarItemUsageDto
{
    public string ItemCode { get; set; } = string.Empty;
    public string ItemName { get; set; } = string.Empty;
    public int QuantityConsumed { get; set; }
    public decimal UnitPrice { get; set; }
}