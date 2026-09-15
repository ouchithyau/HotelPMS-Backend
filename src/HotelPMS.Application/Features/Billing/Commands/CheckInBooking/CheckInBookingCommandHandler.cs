using MediatR;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Enums;
using HotelPMS.Domain.Exceptions;

namespace HotelPMS.Application.Features.Billing.Commands.CheckInBooking;

public class CheckInBookingCommandHandler : IRequestHandler<CheckInBookingCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public CheckInBookingCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(CheckInBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await _context.Bookings.FindAsync(new object[] { request.BookingId }, cancellationToken);
        if (booking == null) throw new DomainException("Booking not found.");

        booking.BookingStatus = BookingStatus.CheckedIn;

        var room = await _context.Rooms.FindAsync(new object[] { booking.RoomId }, cancellationToken);
        if (room != null) room.Status = RoomStatus.Occupied;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}