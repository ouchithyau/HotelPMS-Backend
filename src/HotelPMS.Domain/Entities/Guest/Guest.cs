using HotelPMS.Domain.Common;

namespace HotelPMS.Domain.Entities;

public class Guest : BaseAuditableEntity
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string IdentificationNumber { get; set; } = string.Empty; // NIC or Passport
    public string Address { get; set; } = string.Empty;
    public bool IsVip { get; set; } = false;
    public bool IsBlacklisted { get; set; } = false;
    public bool IsActive { get; set; } = true;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}