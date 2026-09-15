using MediatR;
using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Exceptions;

namespace HotelPMS.Application.Features.Reservations.Commands.ModifyBooking;

public class ModifyBookingCommandHandler : IRequestHandler<ModifyBookingCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public ModifyBookingCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(ModifyBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await _context.Bookings.FindAsync(new object[] { request.BookingId }, cancellationToken);
        if (booking == null) throw new DomainException("Booking not found.");

        booking.CheckInDate = request.CheckInDate;
        booking.CheckOutDate = request.CheckOutDate;
        booking.RoomId = request.RoomId;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}