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
    public Guid? AssignedStaffId { get; set; } // Staff member assigned to clean
    public bool HasMaintenanceIssue { get; set; } = false;
    public string? MaintenanceIssueDescription { get; set; }
    public DateTime? CompletedAt { get; set; }
}