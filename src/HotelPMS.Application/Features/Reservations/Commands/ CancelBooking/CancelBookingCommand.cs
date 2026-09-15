using MediatR;

namespace HotelPMS.Application.Features.Reservations.Commands.CancelBooking;

public record CancelBookingCommand(Guid BookingId) : IRequest<Unit>;