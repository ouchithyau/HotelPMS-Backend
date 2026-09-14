using HotelPMS.Domain.Common;
using HotelPMS.Domain.Enums;

namespace HotelPMS.Domain.Entities;

public class HousekeepingTask : BaseAuditableEntity
{
    public Guid RoomId { get; set; }
    public Room Room { get; set; } = null!;
    public HousekeepingStatus Status { get; set; } = HousekeepingStatus.Dirty;
    public string? Notes { get; set; }
    public string? AssignedToStaffName { get; set; }
}