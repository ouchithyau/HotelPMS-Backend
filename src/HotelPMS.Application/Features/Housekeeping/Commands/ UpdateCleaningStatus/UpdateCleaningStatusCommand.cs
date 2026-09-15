using MediatR;
using HotelPMS.Domain.Enums;

namespace HotelPMS.Application.Features.Housekeeping.Commands.UpdateCleaningStatus;

public record UpdateCleaningStatusCommand(
    Guid RoomId,
    HousekeepingStatus Status,
    string? Notes,
    string? StaffName
) : IRequest<Unit>;