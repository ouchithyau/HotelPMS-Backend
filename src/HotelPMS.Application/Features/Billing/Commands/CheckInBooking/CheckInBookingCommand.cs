using MediatR;

namespace HotelPMS.Application.Features.Billing.Commands.CheckInBooking;

public record CheckInBookingCommand(Guid BookingId) : IRequest<Unit>;