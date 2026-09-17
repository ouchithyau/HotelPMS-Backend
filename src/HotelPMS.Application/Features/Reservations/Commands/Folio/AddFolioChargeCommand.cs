using MediatR;

namespace HotelPMS.Application.Features.Reservations.Commands.Folio;

public record AddFolioChargeCommand(
    Guid ReservationId,
    string ServiceName,
    decimal Amount
) : IRequest<bool>;