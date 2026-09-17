using MediatR;

namespace HotelPMS.Application.Features.Reservations.Commands.CheckIn;

public record CheckInReservationCommand(Guid ReservationId) : IRequest<bool>;