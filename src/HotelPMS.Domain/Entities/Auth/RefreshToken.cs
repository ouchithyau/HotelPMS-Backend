using HotelPMS.Domain.Common;

namespace HotelPMS.Domain.Entities.Auth;

public class RefreshToken : BaseAuditableEntity
{
    public string UserId { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime Expires { get; set; }
    public bool IsExpired => DateTime.UtcNow >= Expires;
    public DateTime? Revoked { get; set; }
    public bool IsActive => Revoked == null && !IsExpired;
}