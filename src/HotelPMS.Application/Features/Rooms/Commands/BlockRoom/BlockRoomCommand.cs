using MediatR;

namespace HotelPMS.Application.Features.Rooms.Commands.BlockRoom;

public record BlockRoomCommand(
    Guid RoomId,
    DateTime StartDate,
    DateTime EndDate,
    string Reason, // e.g., "Plumbing Maintenance & Repair"
    string BlockedByStaffId
) : IRequest<bool>;