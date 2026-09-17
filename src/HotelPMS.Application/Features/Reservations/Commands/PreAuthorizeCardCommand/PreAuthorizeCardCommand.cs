using MediatR;

namespace HotelPMS.Application.Features.Reservations.Commands.PreAuth;

public record PreAuthorizeCardCommand(
    Guid ReservationId,
    decimal DepositAmount,
    string CardNumber
) : IRequest<bool>;