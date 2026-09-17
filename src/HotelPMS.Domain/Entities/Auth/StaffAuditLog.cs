using HotelPMS.Domain.Common;

namespace HotelPMS.Domain.Entities.Auth;

public class StaffAuditLog : BaseAuditableEntity
{
    public string UserId { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty; // e.g., Login, Refund, NightAudit
    public string Details { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}