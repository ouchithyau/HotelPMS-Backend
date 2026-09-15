using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Enums;
using HotelPMS.Domain.Exceptions;

namespace HotelPMS.Application.Features.Billing.Commands.CheckOutAndPay;

public class CheckOutAndPayCommandHandler : IRequestHandler<CheckOutAndPayCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public CheckOutAndPayCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(CheckOutAndPayCommand request, CancellationToken cancellationToken)
    {
        var booking = await _context.Bookings
            .Include(b => b.BookingServices)
            .FirstOrDefaultAsync(b => b.Id == request.BookingId, cancellationToken);

        if (booking == null) throw new DomainException("Booking not found.");

        booking.BookingStatus = BookingStatus.CheckedOut;
        booking.PaymentStatus = request.PaymentStatus;

        var room = await _context.Rooms.FindAsync(new object[] { booking.RoomId }, cancellationToken);
        if (room != null) room.Status = RoomStatus.Cleaning;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}