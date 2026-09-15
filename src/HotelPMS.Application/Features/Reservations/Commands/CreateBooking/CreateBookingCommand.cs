using MediatR;

namespace HotelPMS.Application.Features.Reservations.Commands.CreateBooking;

public record CreateBookingCommand(
    Guid GuestId,
    Guid RoomId,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    int NumberOfGuests
) : IRequest<Guid>;