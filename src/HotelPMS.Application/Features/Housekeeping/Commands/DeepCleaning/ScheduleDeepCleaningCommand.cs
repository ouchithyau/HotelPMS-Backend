using MediatR;

namespace HotelPMS.Application.Features.Housekeeping.Commands.DeepCleaning;

public record ScheduleDeepCleaningCommand(
    Guid RoomId,
    DateTime StartDate,
    DateTime EndDate,
    string Reason, // e.g., "Carpet Shampooing & AC Maintenance"
    string RequestedByStaffId
) : IRequest<bool>;