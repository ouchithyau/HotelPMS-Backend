using MediatR;

namespace HotelPMS.Application.Features.Reservations.Commands.TransferRoom;

public record TransferRoomCommand(
    Guid ReservationId,
    Guid NewRoomId
) : IRequest<bool>;