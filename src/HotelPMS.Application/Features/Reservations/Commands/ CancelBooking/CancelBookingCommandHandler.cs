using MediatR;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Enums;
using HotelPMS.Domain.Exceptions;

namespace HotelPMS.Application.Features.Reservations.Commands.CancelBooking;

public class CancelBookingCommandHandler : IRequestHandler<CancelBookingCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public CancelBookingCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await _context.Bookings.FindAsync(new object[] { request.BookingId }, cancellationToken);
        if (booking == null) throw new DomainException("Booking not found.");

        booking.BookingStatus = BookingStatus.Cancelled;
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}