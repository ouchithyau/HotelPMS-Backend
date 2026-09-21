using MediatR;

namespace HotelPMS.Application.Features.Rooms.Commands.RoomMove;

public record RoomMoveCommand(
    Guid ReservationId,
    Guid CurrentRoomId,
    Guid TargetRoomId,
    string Reason, // e.g., "Guest requested upgrade to Ocean View Suite"
    string AuthorizedByStaffId
) : IRequest<bool>;