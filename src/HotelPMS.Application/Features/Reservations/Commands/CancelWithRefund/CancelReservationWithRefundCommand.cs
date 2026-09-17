using MediatR;

namespace HotelPMS.Application.Features.Reservations.Commands.CancelWithRefund;

public record CancelReservationWithRefundCommand(
    Guid ReservationId,
    string Reason
) : IRequest<bool>;