using HotelPMS.Domain.Common;
using HotelPMS.Domain.Enums;

namespace HotelPMS.Domain.Entities;

public class Room : BaseAuditableEntity
{
    public string RoomNumber { get; set; } = string.Empty; // e.g. "101", "204"
    public Guid RoomTypeId { get; set; }
    public RoomType RoomType { get; set; } = null!;
    public RoomStatus Status { get; set; } = RoomStatus.Available;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<HousekeepingTask> HousekeepingTasks { get; set; } = new List<HousekeepingTask>();
}