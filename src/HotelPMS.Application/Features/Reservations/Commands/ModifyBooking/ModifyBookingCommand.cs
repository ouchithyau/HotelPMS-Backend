using MediatR;

namespace HotelPMS.Application.Features.Reservations.Commands.ModifyBooking;

public record ModifyBookingCommand(Guid BookingId, DateTime CheckInDate, DateTime CheckOutDate, Guid RoomId) : IRequest<Unit>;