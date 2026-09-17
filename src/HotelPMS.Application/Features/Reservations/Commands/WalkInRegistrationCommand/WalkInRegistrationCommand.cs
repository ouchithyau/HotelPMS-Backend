using MediatR;

namespace HotelPMS.Application.Features.Reservations.Commands.WalkIn;

public record WalkInRegistrationCommand(
    Guid GuestId,
    Guid RoomId,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    decimal TotalAmount
) : IRequest<Guid>; // Returns new Reservation ID