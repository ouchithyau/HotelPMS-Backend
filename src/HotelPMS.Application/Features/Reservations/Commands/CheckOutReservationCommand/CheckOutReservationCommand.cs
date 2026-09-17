using MediatR;

namespace HotelPMS.Application.Features.Reservations.Commands.CheckOut;

public record CheckOutReservationCommand(Guid ReservationId) : IRequest<bool>;