using MediatR;

namespace HotelPMS.Application.Features.Housekeeping.Commands.InspectRoom;

public record InspectRoomCommand(
    Guid RoomId,
    string SupervisorId,
    bool IsApproved,
    string InspectionNotes
) : IRequest<bool>;