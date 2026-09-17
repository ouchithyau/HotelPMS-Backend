using MediatR;

namespace HotelPMS.Application.Features.Housekeeping.Commands.AllocateTask;

public record AllocateHousekeepingTaskCommand(
    string StaffId,
    List<Guid> RoomIds,
    string ShiftName,
    DateTime AllocationDate
) : IRequest<bool>;