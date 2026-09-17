namespace HotelPMS.Application.DTOs;

public class LoyaltyDto
{
    public Guid GuestId { get; set; }
    public string TierName { get; set; } = string.Empty; // e.g., "Silver", "Gold", "Platinum"
    public int PointsBalance { get; set; }
    public decimal LifetimeSpend { get; set; }
    public DateTime MemberSince { get; set; }
}